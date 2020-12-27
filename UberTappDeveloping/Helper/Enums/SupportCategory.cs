using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Helper.Enums
{
	public enum SupportCategory
	{
		[Display(Name = "Report A Bug")]
		Report_A_Bug,

		[Display(Name = "Feature Request")]
		Feature_Request,

		[Display(Name = "How To")]
		How_To,

		[Display(Name = "Technical Issue")]
		Technical_Issue,

		[Display(Name = "Delete Your Account")]
		Delete_Your_Account,
		
		[Display(Name = "Other")]
		Other

	} // public enum SupportCategory END //

} // namespace UberTappDeveloping.Helper.Enums END //