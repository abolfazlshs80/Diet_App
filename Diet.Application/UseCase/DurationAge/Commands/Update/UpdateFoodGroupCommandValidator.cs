

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateDurationAgeCommandValidator : AbstractValidator<UpdateDurationAgeCommand>
{
    public UpdateDurationAgeCommandValidator()
    {
        RuleFor(x => x.Id)
               .NotNull().WithMessage("شناسه نباید تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان نباید تهی باشد.")
            .Length(2, 150).WithMessage("عنوان باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

