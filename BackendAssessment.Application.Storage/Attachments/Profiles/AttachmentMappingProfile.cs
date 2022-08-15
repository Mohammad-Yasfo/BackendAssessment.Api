using AutoMapper;
using BackendAssessment.Application.Storage.Dtos;
using BackendAssessment.Common.Extensions;
using BackendAssessment.Domain.Storage.Models;

namespace BackendAssessment.Application.Storage.Profiles
{
    public class AttachmentMappingProfile : Profile
    {
        public AttachmentMappingProfile()
        {
            CreateMap<Attachment, BaseAttachmentDto>()
                .ReverseMap();

            CreateMap<Attachment, AttachmentFileDto>()
                .ReverseMap();

            CreateMap<Attachment, AttachmentContentDto>()
                .ForMember(dest => dest.Content, src => src.Ignore())
                .ForMember(dest => dest.Attachment, src => src.MapFrom(a => a));

            CreateMap<AddAttachmentDto, Attachment>()
                .ForMember(dest => dest.Id, src => Guid.NewGuid())
                .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<Attachment, AttachmentListingItemDto>()
                .ForMember(dest => dest.Type, src => src.MapFrom(a => a.ContentType.ToMediaType().ToString()));
        }
    }
}