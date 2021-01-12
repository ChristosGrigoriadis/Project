using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Helper.CustomDA
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
                value = String.Format("{0:M/d/yyyy}", value); // Fix Localization Date problems

            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "M/d/yyyy",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}