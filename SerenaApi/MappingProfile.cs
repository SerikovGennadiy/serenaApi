using DTO;
using Entities;
using AutoMapper;

namespace SerenaApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IATAPortApiDTO, IATAPort>()
                .ForMember(port => port.PortCode, dto => dto.MapFrom(d => d.iata))
                .ForMember(port => port.geoPoint, dto => dto.MapFrom(d => new GPSCoordinate(d.location.lat, d.location.lon)));
        }
    }
}
