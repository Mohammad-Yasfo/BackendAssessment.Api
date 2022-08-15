namespace BackendAssessment.Application.Hotels.Dtos
{
    public class HotelDto
    {
        public Guid Id { get; set; }
        public byte CurrencyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal RatingValue { get; set; }
        public BookingPriceItemDto Price { get; set; }
        public Guid? FeaturedImageId { get; set; }

        public IList<HotelFacilityListingItemDto> HotelFacilities { get; set; }
    }
}