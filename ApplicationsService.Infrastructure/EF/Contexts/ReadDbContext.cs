using ApplicationsService.Infrastructure.EF.Configurations;
using ApplicationsService.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsService.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<ApplicationReadModel> Applications { get; set; }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("applications");
        base.OnModelCreating(modelBuilder);
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<ApplicationReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ActivitiesReadModel>(configuration);
    }
}