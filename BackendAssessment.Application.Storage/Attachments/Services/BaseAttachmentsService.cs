using BackendAssessment.Application.Storage.Dtos;
using BackendAssessment.Domain.Storage.Models;
using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Storage.Contracts;
using Microsoft.Extensions.Logging;
using BackendAssessment.Common.Extensions;
using AutoMapper;

namespace BackendAssessment.Application.Storage.Services
{
    public class BaseAttachmentsService<T> : IBaseAttachmentsService<T>
        where T : IBaseServiceStorageSettings
    {
        private readonly IAttachmentsRepository Repository;
        private readonly IBlobService<T> BlobService;
        private readonly ILogger<BaseAttachmentsService<T>> Logger;
        private readonly IMapper Mapper;

        #region Constructor

        public BaseAttachmentsService(
            IAttachmentsRepository attachmentsRepository,
            IBlobService<T> blobService,
            IMapper mapper,
            ILogger<BaseAttachmentsService<T>> logger)
        {
            Repository = attachmentsRepository;
            BlobService = blobService;
            Logger = logger;
            Mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<AttachmentContentDto> GetContentByIdAsync(Guid id)
        {
            try
            {
                var attachment = await Repository.GetByIdAsync(id);

                if (attachment == null)
                    throw new Exception("Not Found");

                var attachmentContent = Mapper.Map<Attachment, AttachmentContentDto>(attachment);

                attachmentContent.Content = await BlobService.GetAsync(attachment);

                return attachmentContent;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                throw;
            }
        }

        public async Task<BaseAttachmentDto> GetByIdAsync(Guid id)
        {
            try
            {
                var attachment = await Repository.GetByIdAsync(id);

                if (attachment == null)
                    throw new Exception("Not Found");

                var attachmentDto = Mapper.Map<Attachment, BaseAttachmentDto>(attachment);

                return attachmentDto;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                throw;
            }
        }

        public async Task<BaseAttachmentDto> SaveAsync(AddAttachmentDto addAttachmentDto)
        {
            var attachment = Mapper.Map<AddAttachmentDto, Attachment>(addAttachmentDto);
            attachment.Type = addAttachmentDto.ContentType.ToMediaType();
            // save the file contents
            await BlobService.AddAsync(attachment, addAttachmentDto.FileContents);

            await Repository.AddAsync(attachment);

            var attachmentDto = Mapper.Map<Attachment, BaseAttachmentDto>(attachment);

            return attachmentDto;
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var media = await Repository.GetByIdAsync(id);

                await Repository.RemoveAsync(id);

                await BlobService.DeleteAsync(media.CloudKey);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                throw;
            }
        }

        #endregion
    }
}