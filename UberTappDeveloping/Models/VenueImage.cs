using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    public class VenueImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Byte[] Data { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}