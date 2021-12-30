﻿using Alquileres.Domain;
using AutoMapper;

namespace Alquileres.Common
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<OwnerViewModel, Owner>().ReverseMap();
            CreateMap<OwnerViewModel, Owner>();
            CreateMap<PropertyViewModel, Property>();
            CreateMap<PropertyImageViewModel, PropertyImage>();
            CreateMap<PropertyTraceViewModel, PropertyTrace>();
        }
    }
}
