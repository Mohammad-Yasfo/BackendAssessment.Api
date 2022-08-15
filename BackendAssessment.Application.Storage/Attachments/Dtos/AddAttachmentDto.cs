namespace BackendAssessment.Application.Storage.Dtos
{
    public class AddAttachmentDto
    {
        public string Name { get; set; }

        public long Size { get; set; }

        public string ContentType { get; set; }

        public byte[] FileContents { get; set; }
    }
}