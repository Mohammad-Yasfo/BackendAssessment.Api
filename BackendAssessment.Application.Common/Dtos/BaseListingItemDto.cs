namespace BackendAssessment.Application.Common.Dtos
{
    public class BaseListingItemDto<TKeyType>
    {
        public TKeyType Id { get; set; }
        public string Name { get; set; }
    }

    public class BaseListingItemDto : BaseListingItemDto<Guid>
    {
    }

    public class BaseListingReferencesDto<TKeyType> : BaseListingItemDto<TKeyType>
    {
        public bool IsPublished { get; set; }
    }
}