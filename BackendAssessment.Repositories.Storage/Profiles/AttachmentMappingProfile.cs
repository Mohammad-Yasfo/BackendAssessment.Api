using AutoMapper;
using BackendAssessment.Domain.Storage.Models;
using BackendAssessment.Repositories.Storage.Entities;

namespace BackendAssessment.Repositories.Storage.Profiles
{
    public class AttachmentMappingProfile : Profile
    {
        public AttachmentMappingProfile()
        {
            CreateMap<Attachment, BaseAttachmentEntity>()
                .ReverseMap();
        }
    }
}