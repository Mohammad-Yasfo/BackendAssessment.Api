namespace BackendAssessment.Application.Hotels.Dtos
{
    public class FilterLocationDto
    {
        public double Radius { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}