namespace BackendAssessment.Application.Hotels.Dtos
{
    public class FilterDto
    {
        public double? Radius { get; set; }
        public double? Budget { get; set; }
        public FilterLocationDto? Location { get; set; }
        public IList<byte>? Facilities { get; set; }
        public IList<byte>? Services { get; set; }
        public IList<byte>? HotelTypes { get; set; }
        public string? SortBy { get; set; }
    }
}