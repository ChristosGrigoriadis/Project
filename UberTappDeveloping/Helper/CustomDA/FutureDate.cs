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
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "M/d/yyyy hh:mm:ss tt",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}