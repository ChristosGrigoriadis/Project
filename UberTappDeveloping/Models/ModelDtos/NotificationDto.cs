using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UberTappDeveloping.DAL;
using UberTappDeveloping.Helper.Enums;
using System.Data.Entity;

namespace UberTappDeveloping.Models.ModelDtos
{
    public class NotificationDto
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public NotificationType Type { get; set; }
        public DateTime? OriginalDate { get; set; }
        public int? OriginalVenueId { get; set; }
        public string OriginalDescription { get; set; }
        public string OriginalVenueName
        {
            get
            {
                return OriginalVenueId.HasValue ? context.Venues.SingleOrDefault(v => v.Id == OriginalVenueId).Name : null;
            }
        }

        public string VenueProfileImage
        {
            get
            {
                return Convert.ToBase64String(context.VenueProfileImage.SingleOrDefault(i => i.VenueId == Event.VenueId).Data);
            }
        }

        public int EventId { get; set; }
        public EventDto Event { get; set; }
    }
}