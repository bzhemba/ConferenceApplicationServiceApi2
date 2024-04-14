using ConferenceApplicationService.Shared.Commands;
using ApplicationsService.Domain.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationsService.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IApplicationFactory, ApplicationFactory>();
            
        return services;
    }
}