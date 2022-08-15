namespace BackendAssessment.Application.Storage.Dtos
{
    public class BaseAttachmentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string ContentType { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}