

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseFoodStuffAllergyCommandValidator : AbstractValidator<CreateCaseFoodStuffAllergyCommand>
{
    public CreateCaseFoodStuffAllergyCommandValidator()
    {
        RuleFor(x => x.CaseId)
    .NotNull().WithMessage("شناسه پرونده نباید تهی باشد.")
    .NotEmpty().WithMessage("شناسه پرونده نباید خالی باشد.");

        RuleFor(x => x.FoodStuffId)
            .NotNull().WithMessage("شناسه ماده غذایی نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه ماده غذایی نباید خالی باشد.");


    }
}

