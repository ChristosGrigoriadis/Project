using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models.ModelDtos
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }


        public int VenueId { get; set; }
        public VenueDto Venue { get; set; }
    }
}