using AutoMapper;
using BackendAssessment.Application.Hotels.Dtos;
using BackendAssessment.Domain.Hotels;

namespace BackendAssessment.Application.Hotels.Profiles
{
    public class HotelsMappingProfile : Profile
    {
        public HotelsMappingProfile()
        {
            CreateMap<FilterLocationDto, HotelFilterLocation>();

            CreateMap<FilterDto, HotelFilter>();

            CreateMap<BookingPriceItemDto, BookingPrice>()
                .ReverseMap();

            CreateMap<HotelFacilityListingItemDto, HotelFacility>()
                .ReverseMap();

            CreateMap<HotelListingItemDto, Hotel>()
                .ReverseMap();
        }
    }
}