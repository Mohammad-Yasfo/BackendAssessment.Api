using Microsoft.AspNetCore.Http;

namespace BackendAssessment.Application.Storage.Dtos
{
    public class AddAttachmentFileDto
    {
        public IFormFile Attachment { get; set; }
    }
}