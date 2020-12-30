using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.Controllers.API
{
    public class EmailsController : ApiController
    {
        [HttpPost]
        [Authorize]
        public IHttpActionResult SendEmail(Email email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("ubertappcb11@gmail.com");
            mailMessage.To.Add(email.To);
            mailMessage.Subject = email.Subject.ToString();
            mailMessage.Body = email.Body;
            mailMessage.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("ubertappcb11@gmail.com", "Qwerty11!");
            smtp.Port = 587;

            smtp.Send(mailMessage);

            return Ok();
        }

    } // public class EmailsController : ApiController END //

} // namespace UberTappDeveloping.Controllers.API END //
