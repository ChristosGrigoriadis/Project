using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PayPal.Api;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Helper.Roles;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.Controllers
{
	public class PayPalController : Controller
	{
		private PayPal.Api.Payment payment;
		private ApplicationDbContext context;

		public PayPalController()
		{
			context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			context.Dispose();
		}

		#region GET

		[Authorize(Roles = RoleNames.BeerEnthusiast)]
		public ActionResult ViewPermiumOffer(string id)
		{
			var applicationUser = context.Users.SingleOrDefault(u => u.Id == id);
			if (applicationUser == null)
				return HttpNotFound();

			return View("ViewPermiumOffer", applicationUser);

		} // public ActionResult ViewPermiumOffer(string id) END //

		[Authorize(Roles = RoleNames.BeerEnthusiast)]
		public ActionResult SuccessfulPayment()
		{
			return View("SuccessfulPayment");

		} // public ActionResult SuccessfulPayment END //

		#endregion

		#region POST

		[Authorize(Roles = RoleNames.BeerEnthusiast)]
		public ActionResult PaymentWithPaypal(string Cancel = null)
		{
			APIContext apiContext = PaypalConfiguration.GetAPIContext();
			try
			{
				string payerId = Request.Params["PayerID"];
				if (string.IsNullOrEmpty(payerId))
				{
					string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PayPal/PaymentWithPayPal?";
					var guid = Convert.ToString((new Random()).Next(100000));
					var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
					var links = createdPayment.links.GetEnumerator();
					string paypalRedirectUrl = null;
					while (links.MoveNext())
					{
						Links lnk = links.Current;
						if (lnk.rel.ToLower().Trim().Equals("approval_url"))
						{
							paypalRedirectUrl = lnk.href;
						}
					}

					Session.Add(guid, createdPayment.id);
					return Redirect(paypalRedirectUrl);
				}
				else
				{
					var guid = Request.Params["guid"];
					var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);

					if (executedPayment.state.ToLower() != "approved")
					{
						return RedirectToAction("ErrorPage", "Home");
					}
				}
			}
			catch (Exception)
			{
				return RedirectToAction("ErrorPage", "Home");
			}

			return View("SuccessfulPayment");
			

		} // public ActionResult PaymentWithPaypal(string Cancel = null) END //

		#endregion

		private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
		{
			var paymentExecution = new PaymentExecution()
			{
				payer_id = payerId
			};
			this.payment = new Payment()
			{
				id = paymentId
			};
			return this.payment.Execute(apiContext, paymentExecution);

		} // private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId) END //

		private Payment CreatePayment(APIContext apiContext, string redirectUrl)
		{
			var itemList = new ItemList()
			{
				items = new List<Item>()
			};

			itemList.items.Add(new Item()
			{
				name = "Premium User",
				currency = "EUR",
				price = "5",
				quantity = "1",
				sku = "ACKLP12345"
			});
			var payer = new Payer()
			{
				payment_method = "paypal"
			};

			var redirUrls = new RedirectUrls()
			{
				cancel_url = redirectUrl + "&Cancel=true",
				return_url = redirectUrl
			};

			var details = new Details()
			{
				tax = "2",
				shipping = "3",
				subtotal = "5"
			};

			var amount = new Amount()
			{
				currency = "EUR",
				total = "10",
				details = details
			};

			var transactionList = new List<Transaction>();
			transactionList.Add(new Transaction()
			{
				description = "UberTapp Premium Member",
				invoice_number = "12345678910ftoukaivgaino",
				amount = amount,
				item_list = itemList
			});

			this.payment = new Payment()
			{
				intent = "sale",
				payer = payer,
				transactions = transactionList,
				redirect_urls = redirUrls
			};

			return this.payment.Create(apiContext);

		} // private Payment CreatePayment(APIContext apiContext, string redirectUrl) END //

	} // public class PayPalController : Controller END //

} // namespace UberTappDeveloping.Controllers END //