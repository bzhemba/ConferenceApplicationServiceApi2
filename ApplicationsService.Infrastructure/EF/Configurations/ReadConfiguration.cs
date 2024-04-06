using ApplicationsService.Domain.Consts;
using ApplicationsService.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationsService.Infrastructure.EF.Configurations;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<ApplicationReadModel>, IEntityTypeConfiguration<ActivitiesReadModel>
{
    public void Configure(EntityTypeBuilder<ApplicationReadModel> builder)
    {
        builder.ToTable("Applications");
        builder.HasKey(a => a.Id);
        
    }

    public void Configure(EntityTypeBuilder<ActivitiesReadModel> builder)
    {
        builder.ToTable("Activities");
        builder.HasNoKey();
        builder.Property(activity => activity.Type)
            .HasConversion(activity => activity.ToString(),
                activity => (ActivityType)Enum.Parse(typeof(ActivityType), activity));
    }
}