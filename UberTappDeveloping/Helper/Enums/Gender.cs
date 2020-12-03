using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Helper.Enums
{
    public enum Gender
    {
        Female = 1,
		Male,
		Transgender,
		[Display(Name = "Two Spirit")]
		Two_Spirit,
		[Display(Name = "Non Binary")]
		Non_Binary,
		Genderqueer,
		[Display(Name = "Gender Expression")]
		Gender_Expression,
		[Display(Name = "Gender Fluid")]
		Gender_Fluid,
		[Display(Name = "Gender Neutral")]
		Gender_Neutral,
		Other,
		[Display(Name = "Rather Not Say")]
		Rather_Not_Say
	}
}