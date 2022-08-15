namespace BackendAssessment.Application.Common.Dtos
{
    public class BaseListingItemCollectionDto<TDto, T>
    {
        public IList<TDto> Items { get; set; }
    }

    public class BaseListingItemCollectionDto<T>
    {
        public IList<T> Items { get; set; }
    }
}