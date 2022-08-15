using BackendAssessment.Application.Storage.Configuration;
using BackendAssessment.Application.Storage.Contracts;
using BackendAssessment.Application.Storage.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssessment.Api.Controllers.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1.0/attachments")]
    [Authorize]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IBaseAttachmentsService<DocumentsStorageSettings> attachmentsService;
        private readonly ILogger<AttachmentsController> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attachmentsService"></param>
        /// <param name="logger"></param>
        public AttachmentsController(
            IBaseAttachmentsService<DocumentsStorageSettings> attachmentsService,
            ILogger<AttachmentsController> logger)
        {
            this.logger = logger;
            this.attachmentsService = attachmentsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var attachment = await attachmentsService.GetContentByIdAsync(id);

                return File(new MemoryStream(attachment.Content), attachment.Attachment.ContentType, attachment.Attachment.Name);
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            try
            {
                var attachment = await FileToAttachment(file);

                await attachmentsService.SaveAsync(attachment);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #region Private Methods

        private async Task<AddAttachmentDto> FileToAttachment(IFormFile file)
        {
            byte[] fileContents;
            var attachment = file;
            using (var ms = new MemoryStream())
            {
                await attachment.CopyToAsync(ms);
                fileContents = ms.ToArray();
            }

            var addAttachment = new AddAttachmentDto()
            {
                ContentType = attachment.ContentType,
                Name = attachment.FileName,
                Size = attachment.Length,
                FileContents = fileContents,
            };

            return addAttachment;
        }

        #endregion
    }
}