using ApplicationsService.Domain.ValueObjects;
using ApplicationsService.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsService.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Domain.ValueObjects.Application> Applications { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("applications");
        base.OnModelCreating(modelBuilder);
            
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Domain.ValueObjects.Application>(configuration);
        modelBuilder.ApplyConfiguration<Activity>(configuration);
    }
}