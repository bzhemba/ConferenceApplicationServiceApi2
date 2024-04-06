using ApplicationService.Shared.Queries;
using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationsService.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddQueries();
            
        return services;
    }
}