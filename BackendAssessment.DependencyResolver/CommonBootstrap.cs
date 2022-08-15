using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;
using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Storage.Configuration;
using BackendAssessment.Infrastructure.AzureBlobStorage;
using BackendAssessment.Application.Storage.Validators;
using BackendAssessment.Application.Common.Configuration;
using BackendAssessment.Repositories.Hotels;
using BackendAssessment.Repositories.Storage;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.DependencyResolver
{
    [ExcludeFromCodeCoverage]
    public static class CommonBootstrap
    {
        public static IServiceCollection RegisterCommonDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionConfig = configuration.GetDbConnectionConfiguration();

            return services
                .AddCommonApplication(configuration)
                .AddCommonRepositories()
                .ConfigureBlobStorage()
                .AddCommonMapping()
                .AddDbContexts(dbConnectionConfig);
        }

        public static DbConnectionConfiguration GetDbConnectionConfiguration(this IConfiguration configuration)
        {
            return new DbConnectionConfiguration
            {
                HotelsConnectionString = configuration.GetConnectionString("HotelsConnectionString"),
                StorageConnectionString = configuration.GetConnectionString("StorageConnectionString"),
            };
        }

        private static IServiceCollection AddDbContexts(this IServiceCollection services, DbConnectionConfiguration dbConnectionConfig)
        {
            return services
                .AddDbContext<HotelsDbContext>(options => options.UseSqlServer(dbConnectionConfig.HotelsConnectionString))
                .AddDbContext<AttachmentsDbContext>(options => options.UseSqlServer(dbConnectionConfig.StorageConnectionString));
        }

        private static IServiceCollection AddCommonRepositories(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddCommonApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure service layer
            services.TryAddSingleton<StoreAttachmentValidator>();

            return services;
        }

        public static IServiceCollection ConfigureBlobStorage(this IServiceCollection services)
        {
            return services
                .AddSingleton<IBlobConnectionFactory, AzureBlobConnectionFactory>()
                .AddSingleton<IBlobService<DocumentsStorageSettings>, AzureBlobService<DocumentsStorageSettings>>();
        }

        private static IServiceCollection AddCommonMapping(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(
                    typeof(Application.Storage.Profiles.AttachmentMappingProfile).Assembly,
                    typeof(Repositories.Storage.Profiles.AttachmentMappingProfile).Assembly
                );
        }
    }
}