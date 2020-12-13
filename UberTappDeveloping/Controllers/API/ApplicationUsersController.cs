using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Helper.Roles;

namespace UberTappDeveloping.Controllers.API
{
	public class ApplicationUsersController : ApiController
	{
		private ApplicationDbContext context;

		public ApplicationUsersController()
		{
			context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			context.Dispose();
		}

		#region DELETE

		// DELETE: /api/applicationusers/id
		//[Authorize(Roles = RoleNames.Admin)]
		[HttpDelete]
		public IHttpActionResult Delete(string id)
		{
			var userDB = context.Users.SingleOrDefault(u => u.Id == id);

			if (userDB == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			context.Users.Remove(userDB);
			context.SaveChanges();

			return Ok();
		}

		#endregion
	}
}
