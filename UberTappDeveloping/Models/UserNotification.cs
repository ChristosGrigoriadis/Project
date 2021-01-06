using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string BeerEnthusiastId { get; set; }
        public ApplicationUser BeerEnthusiast { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }

        public bool IsRead { get; set; }
    }
}