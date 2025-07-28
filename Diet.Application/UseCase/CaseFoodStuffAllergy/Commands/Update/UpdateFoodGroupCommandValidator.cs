

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseFoodStuffAllergyCommandValidator : AbstractValidator<UpdateCaseFoodStuffAllergyCommand>
{
    public UpdateCaseFoodStuffAllergyCommandValidator()
    {
        RuleFor(x => x.CaseId)
            .NotNull().WithMessage("شناسه پرونده نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه پرونده نباید خالی باشد.");

        RuleFor(x => x.FoodStuffId)
            .NotNull().WithMessage("شناسه ماده غذایی نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه ماده غذایی نباید خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نباید خالی باشد.");

    }
}

