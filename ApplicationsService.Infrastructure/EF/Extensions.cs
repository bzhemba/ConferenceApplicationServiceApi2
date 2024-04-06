using ApplicationService.Shared.Options;
using ApplicationsService.Application.Services;
using ApplicationsService.Domain.Repositories;
using ApplicationsService.Infrastructure.EF.Contexts;
using ApplicationsService.Infrastructure.EF.Options;
using ApplicationsService.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationsService.Infrastructure.EF;

public static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationsRepository, PostgresApplicationRepository>();
       
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<ReadDbContext>(ctx => 
            ctx.UseNpgsql(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx => 
            ctx.UseNpgsql(options.ConnectionString));

        return services;
    }
}