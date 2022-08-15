using BackendAssessment.Domain.Enums;

namespace BackendAssessment.Domain.Storage.Models
{
    public class Attachment
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public string ContentType { get; set; }

        public string CloudKey { get; set; }

        public FileType Type { get; set; }
    }
}