using FluentValidation;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Validators;

public class SaveSongRequestValidator : AbstractValidator<SaveSongRequest>
{
    public SaveSongRequestValidator()
    {
        RuleFor(s => s.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the title of the song");

        RuleFor(s => s.ReleaseDate)
            .NotEmpty()
            .WithMessage("you must provide the release date of the song");

        RuleFor(s => s.IdArtist)
            .NotEmpty()
            .WithMessage("you must provide the artist of the song");

        RuleFor(s => s.IdLabel)
            .NotEmpty()
            .WithMessage("you must provide the label of the song");
    }
}