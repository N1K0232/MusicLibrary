using FluentValidation;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Validators;

public class SaveArtistRequestValidator : AbstractValidator<SaveArtistRequest>
{
    public SaveArtistRequestValidator()
    {
        RuleFor(a => a.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the first name of the artist");

        RuleFor(a => a.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the last name of the artist");

        RuleFor(a => a.BirthDate)
            .NotEmpty()
            .WithMessage("you must provide the birthdate of the artist");

        RuleFor(a => a.ArtName)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the art name of the artist");

        RuleFor(a => a.IdLabel)
            .NotEmpty()
            .WithMessage("you must provide the record label of the artist");
    }
}