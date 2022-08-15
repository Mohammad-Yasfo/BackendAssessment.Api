using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Services;
using BackendAssessment.Repositories.Hotels.Repositories;

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
            return services
                .AddScoped<IHotelsRepository, HotelsRepository>()
                .AddScoped<ISearchRepository, SearchRepository>();
        }

        private static IServiceCollection AddHotelsApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure service layer

            return services
                .AddScoped<IHotelsService, HotelsService>()
                .AddScoped<ISearchService, SearchService>();
        }

        private static IServiceCollection AddHotelsMapping(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(
                    typeof(Application.Hotels.Profiles.HotelsMappingProfile).Assembly,
                    typeof(Repositories.Hotels.Profiles.HotelsMappingProfile).Assembly
                );
        }
    }
}