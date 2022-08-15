namespace BackendAssessment.Application.Common.Dtos
{
    public class PaginatedDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public string FirstPageUrl { get; set; }
        public string NextPageUrl { get; set; }
        public string PrevPageUrl { get; set; }
    }
}