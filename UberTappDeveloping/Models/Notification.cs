using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.Helper.Enums;

namespace UberTappDeveloping.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDate { get; set; }
        public int? OriginalVenueId { get; set; }
        public string OriginalDescription { get; set; }


        public int EventId { get; set; }
        public Event Event { get; set; }

        
    }
}