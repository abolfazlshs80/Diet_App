

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateDurationAgeCommandValidator : AbstractValidator<CreateDurationAgeCommand>
{
    public CreateDurationAgeCommandValidator()
    {

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان نباید تهی باشد.")
            .Length(2, 150).WithMessage("عنوان باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

