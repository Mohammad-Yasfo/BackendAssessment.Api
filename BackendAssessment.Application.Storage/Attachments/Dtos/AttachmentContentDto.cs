namespace BackendAssessment.Application.Storage.Dtos
{
    public class AttachmentContentDto
    {
        public byte[] Content { get; set; }

        public BaseAttachmentDto Attachment { get; set; }
    }
}