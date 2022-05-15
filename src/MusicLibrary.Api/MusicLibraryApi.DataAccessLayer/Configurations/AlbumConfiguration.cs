using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibraryApi.DataAccessLayer.Configurations.Common;
using MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.DataAccessLayer.Configurations;

internal class AlbumConfiguration : BaseEntityConfiguration<Album>
{
    public override void Configure(EntityTypeBuilder<Album> builder)
    {
        base.Configure(builder);

        builder.ToTable("Albums");

        builder.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.ReleaseDate)
            .IsRequired();
    }
}