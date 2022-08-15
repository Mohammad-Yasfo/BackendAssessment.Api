using AutoMapper;
using BackendAssessment.Application.Storage.Contracts;
using BackendAssessment.Domain.Storage.Models;
using BackendAssessment.Repositories.Storage.Entities;

namespace BackendAssessment.Repositories.Storage.Repositories
{
    public class AttachmentsRepository : BaseAttachmentsRepository, IAttachmentsRepository
    {
        public AttachmentsRepository(
            AttachmentsDbContext context,
            IMapper mapper
            )
            : base(context, mapper)
        {
        }

        public async Task<Attachment> GetByIdAsync(Guid id)
        {
            var attachmentEntity = await Context.Attachments.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
            var attachment = mapper.Map<BaseAttachmentEntity, Attachment>(attachmentEntity);
            return attachment;
        }

        public async Task<Attachment> AddAsync(Attachment attachment)
        {
            try
            {
                var attachmentEntity = new BaseAttachmentEntity()
                {
                    Id = attachment.Id,
                    Name = attachment.Name,
                    CloudKey = attachment.CloudKey,
                    ContentType = attachment.ContentType,
                    Size = attachment.Size
                };
                var addedEntity = await Context.Attachments.AddAsync(attachmentEntity);
                var result = mapper.Map<BaseAttachmentEntity, Attachment>(addedEntity.Entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("error in adding  files to database");
            }
        }

        public async Task RemoveAsync(Guid id)
        {
            var attachment = await Context.Attachments.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));

            Context.Attachments.Remove(attachment);
        }
    }
}