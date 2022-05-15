using FluentValidation;
using MusicLibraryApi.Shared.Models.Requests;

namespace MusicLibraryApi.BusinessLayer.Validators;

public class SaveRecordLabelRequestValidator : AbstractValidator<SaveRecordLabelRequest>
{
    public SaveRecordLabelRequestValidator()
    {
        RuleFor(rl => rl.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the name of the record label");

        RuleFor(rl => rl.City)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the city of the record label");

        RuleFor(rl => rl.Country)
            .NotNull()
            .NotEmpty()
            .WithMessage("you must provide the country of the record label");

        RuleFor(rl => rl.FoundationDate)
            .NotEmpty()
            .WithMessage("you must provide the foundation date of the record label");
    }
}