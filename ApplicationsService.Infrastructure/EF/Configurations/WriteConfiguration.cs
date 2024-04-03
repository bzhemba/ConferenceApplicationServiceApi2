using ApplicationsService.Domain.Consts;
using ApplicationsService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ApplicationId = System.ApplicationId;

namespace ApplicationsService.Infrastructure.EF.Configurations;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Domain.ValueObjects.Application>, IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Domain.ValueObjects.Application> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .Property(application => application.Id)
            .HasConversion(id => id.Value, id => 
                new Domain.ValueObjects.ApplicationId(id));
        
        
        builder.Property(application => application.UserId).IsRequired();
        builder.Property(application => application.Activity)
            .HasConversion(
                activity => activity.ToString(),
                activity => (ActivityType)Enum.Parse(typeof(ActivityType), activity));
        builder.Property(application => application.Title).HasMaxLength(100)
            .IsRequired();
        builder.Property(application => application.Description)
            .IsRequired(false).HasMaxLength(300);
        builder.Property(application => application.Outline)
            .IsRequired().HasMaxLength(1000);
        builder.ToTable("Applications");
    }

    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.Property(ac => ac.Type);
        builder.ToTable("Activities");
    }
}