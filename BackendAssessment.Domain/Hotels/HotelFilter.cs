namespace BackendAssessment.Domain.Hotels
{
    public class HotelFilter
    {
        public double? Radius { get; set; }
        public double? Budget { get; set; }
        public HotelFilterLocation? Location { get; set; }
        public IList<byte>? Facilities { get; set; }
        public IList<byte>? Services { get; set; }
        public IList<byte>? HotelTypes { get; set; }
        public string? SortBy { get; set; }
    }
}
