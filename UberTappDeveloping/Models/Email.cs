using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UberTappDeveloping.Helper.Enums;

namespace UberTappDeveloping.Models
{
	public class Email
	{
		public string To { get; private set; } = "ubertappcb11@gmail.com";
		public SupportCategory Subject { get; set; }
		public string Body { get; set; }

	} // public class Email END //

} // namespace UberTappDeveloping.Models END //