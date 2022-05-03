using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibraryApi.DataAccessLayer.Configurations.Common;
using MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.DataAccessLayer.Configurations;

internal class RecordLabelConfiguration : BaseEntityConfiguration<RecordLabel>
{
    public override void Configure(EntityTypeBuilder<RecordLabel> builder)
    {
        base.Configure(builder);

        builder.ToTable("RecordLabels");

        builder.Property(rl => rl.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(rl => rl.FoundationDate)
            .IsRequired();

        builder.Property(rl => rl.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(rl => rl.Country)
            .HasMaxLength(50)
            .IsRequired();
    }
}