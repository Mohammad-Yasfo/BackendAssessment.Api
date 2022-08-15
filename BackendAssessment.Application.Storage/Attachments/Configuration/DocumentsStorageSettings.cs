using BackendAssessment.Application.Common.Storage.Contracts;

namespace BackendAssessment.Application.Storage.Configuration
{
    public class DocumentsStorageSettings : IBaseServiceStorageSettings
    {
        public string ContainerName
        {
            get => "documents";
        }
    }
}