namespace BackendAssessment.Application.Common.Dtos
{
    public class PagingDto
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}