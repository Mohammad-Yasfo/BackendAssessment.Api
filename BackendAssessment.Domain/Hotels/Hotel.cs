namespace BackendAssessment.Domain.Hotels
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public byte CurrencyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal RatingValue { get; set; }
        public BookingPrice Price { get; set; }
        public IList<byte> Facilities { get; set; }

        public Guid? FeaturedImageId { get; set; }
    }
}