using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UberTappDeveloping.Helper.CustomDA;


namespace UberTappDeveloping.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Event's Description")]
        public string Description { get; set; }

        [FutureDate(ErrorMessage = "Event's Date must be a future date")]
        [Display(Name = "Event's Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        public bool IsCanceled { get; set; }

        [Display(Name = "My Venues")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}