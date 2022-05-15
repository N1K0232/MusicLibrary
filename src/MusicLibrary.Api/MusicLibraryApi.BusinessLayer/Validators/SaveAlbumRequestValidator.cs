using FluentValidation;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Validators;

public class SaveAlbumRequestValidator : AbstractValidator<SaveAlbumRequest>
{
    public SaveAlbumRequestValidator()
    {
        RuleFor(a => a.IdArtist)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must add the artist");

        RuleFor(a => a.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must add the album name");

        RuleFor(a => a.ReleaseDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("you must add the release date");
    }
}