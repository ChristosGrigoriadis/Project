using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Helper.CustomDA
{
    public class IsAdult : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
                value = String.Format("{0:M/d/yyyy}", value); // Fix Localization Date problems
            
            
            DateTime userAge;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "M/d/yyyy",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out userAge);


            return isValid && (DateTime.Now.Year - userAge.Year >= 18);
        }
    }
}