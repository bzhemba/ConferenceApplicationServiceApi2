using ApplicationsService.Domain.Consts;
using ApplicationsService.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationsService.Infrastructure.EF.Configurations;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<ApplicationReadModel>, IEntityTypeConfiguration<EnumReadModel>
{
    public void Configure(EntityTypeBuilder<ApplicationReadModel> builder)
    {
        builder.ToTable("Applications");
        builder.HasKey(a => a.Id);
    }

    public void Configure(EntityTypeBuilder<EnumReadModel> builder)
    {
        builder.ToTable("Activities");
        builder.HasNoKey();
    }
}