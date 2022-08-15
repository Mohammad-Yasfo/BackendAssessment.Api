using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;
using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Storage.Configuration;
using BackendAssessment.Infrastructure.AzureBlobStorage;
using BackendAssessment.Application.Storage.Validators;

namespace BackendAssessment.DependencyResolver
{
    [ExcludeFromCodeCoverage]
    public static class HotelsBootstrap
    {
        public static IServiceCollection RegisterHotelsDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddHotelsApplication(configuration)
                .AddHotelsRepositories()
                .AddHotelsMapping();
        }

        private static IServiceCollection AddHotelsRepositories(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddHotelsApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure service layer

            return services;
        }

        private static IServiceCollection AddHotelsMapping(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(
                    typeof(Application.Storage.Profiles.AttachmentMappingProfile).Assembly,
                    typeof(Repositories.Storage.Profiles.AttachmentMappingProfile).Assembly
                );
        }
    }
}