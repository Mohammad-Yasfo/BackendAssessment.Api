using System.Diagnostics.CodeAnalysis;

namespace BackendAssessment.Application.Common.Configuration
{
    [ExcludeFromCodeCoverage]
    public class DbConnectionConfiguration
    {
        public string HotelsConnectionString { get; set; }
        public string StorageConnectionString { get; set; }
        public bool AzureIdentity { get; set; }
    }
}