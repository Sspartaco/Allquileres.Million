using Alquileres.Domain;
using AutoMapper;

namespace Alquileres.Mapping.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<OwnerViewModel, Owner>().ReverseMap();
            CreateMap<OwnerViewModel, Owner>();
            CreateMap<PropertyViewModel, Property>();
        }
    }
}
