using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using UberTappDeveloping.Models;
using UberTappDeveloping.Models.ModelDtos;

namespace UberTappDeveloping.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Venue, VenueDto>();
        }
    }
}