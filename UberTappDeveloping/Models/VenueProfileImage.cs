using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UberTappDeveloping.Models
{
    [Table("VenueProfileImage")]
    public class VenueProfileImage
    {
        [ForeignKey("Venue")]
        [Key]
        public int VenueId { get; set; }
        public string Name { get; set; }
        public Byte[] Data { get; set; }

        public Venue Venue { get; set; }
    }
}