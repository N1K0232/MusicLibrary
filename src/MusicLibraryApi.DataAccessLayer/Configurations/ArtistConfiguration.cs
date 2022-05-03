using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibraryApi.DataAccessLayer.Configurations.Common;
using MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.DataAccessLayer.Configurations;

internal class ArtistConfiguration : BaseEntityConfiguration<Artist>
{
    public override void Configure(EntityTypeBuilder<Artist> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.BirthDate)
            .IsRequired();

        builder.Property(a => a.ArtName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(a => a.RecordLabel)
            .WithMany(rl => rl.Artists)
            .HasForeignKey(a => a.IdLabel)
            .IsRequired();
    }
}