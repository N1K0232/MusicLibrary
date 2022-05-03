using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibraryApi.DataAccessLayer.Configurations.Common;
using MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.DataAccessLayer.Configurations;

internal class SongConfiguration : BaseEntityConfiguration<Song>
{
    public override void Configure(EntityTypeBuilder<Song> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.ReleaseDate)
            .IsRequired();

        builder.Property(s => s.SongType)
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsRequired();

        builder.HasOne(s => s.RecordLabel)
            .WithMany(rl => rl.Songs)
            .HasForeignKey(s => s.IdLabel)
            .IsRequired();

        builder.HasOne(s => s.Artist)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.IdArtist)
            .IsRequired();
    }
}