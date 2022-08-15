namespace BackendAssessment.Application.Hotels.Dtos
{
    public class HotelListingItemDto
    {
        public Guid Id { get; set; }
        public byte CurrencyId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal RatingValue { get; set; }
        public BookingPriceItemDto Price { get; set; }
        public Guid? FeaturedImageId { get; set; }
    }
}