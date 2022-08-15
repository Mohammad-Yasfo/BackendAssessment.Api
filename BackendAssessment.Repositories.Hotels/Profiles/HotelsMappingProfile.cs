using AutoMapper;
using BackendAssessment.Domain.Hotels;
using BackendAssessment.Repositories.Hotels.Entities;

namespace BackendAssessment.Repositories.Hotels.Profiles
{
    public class HotelsMappingProfile : Profile
    {
        public HotelsMappingProfile()
        {
            CreateMap<Hotel, HotelEntity>()
                .ReverseMap();
        }
    }
}