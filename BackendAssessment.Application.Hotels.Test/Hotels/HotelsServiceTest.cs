using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using AutoMapper;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Dtos;
using BackendAssessment.Application.Hotels.Services;
using BackendAssessment.Domain.Hotels;
using NSubstitute;
using Xunit;

namespace BackendAssessment.Application.Hotels.Test
{
    public class HotelsServiceTest
    {
        #region Properties

        private readonly Fixture fixture;
        private readonly IMapper mapper;
        private readonly byte countryId;
        private readonly Guid hotelId;

        #endregion

        #region Constructor

        public HotelsServiceTest()
        {
            fixture = new Fixture();
            fixture
                .Customize(new AutoNSubstituteCustomization());

            fixture
                .Behaviors.Add(new OmitOnRecursionBehavior());


            hotelId = Guid.NewGuid();
            countryId = 1;

            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.Hotels.Profiles.HotelsMappingProfile());
                mc.AddProfile(new Repositories.Hotels.Profiles.HotelsMappingProfile());
            });

            mapper = config.CreateMapper();
            fixture.Inject<IMapper>(mapper);
        }

        #endregion

        #region Methods

        [Fact]
        public async void Get_Hotel_By_Id_Should_Returen_OK_When_It_Got_Successfully()
        {
            // Arrange
            var hotelDtoToSend = fixture.Create<HotelDto>();

            var hotelModel = mapper.Map<Hotel>(hotelDtoToSend);

            var hotelsRepository = fixture.FreezeSubstitute<IHotelsRepository>();
            hotelsRepository.GetProfileAsync(hotelId).ReturnsForAnyArgs(new Hotel
            {
                Id = hotelId,
                Name = hotelDtoToSend.Name,
                Description = hotelDtoToSend.Description,
                CurrencyId = hotelDtoToSend.CurrencyId,
                Price = new BookingPrice()
                {
                    MinimumValue = hotelDtoToSend.Price.MinimumValue,
                    MaximumValue = hotelDtoToSend.Price.MaximumValue,
                },
                RatingValue = hotelDtoToSend.RatingValue
            });

            var hotelsService = fixture.FreezeSubstitute<IHotelsService>();
            hotelsService.GetProfileAsync(hotelId).ReturnsForAnyArgs(mapper.Map<HotelListingItemDto>(hotelDtoToSend));

            // Act
            var service = fixture.Create<HotelsService>();
            var result = await service.GetProfileAsync(hotelId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HotelListingItemDto>();

            result.Name.Should().Be(hotelDtoToSend.Name);
            result.RatingValue.Should().Be(hotelDtoToSend.RatingValue);
        }

        #endregion
    }
}