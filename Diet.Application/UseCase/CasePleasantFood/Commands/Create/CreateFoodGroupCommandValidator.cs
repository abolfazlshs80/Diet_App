

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCasePleasantFoodCommandValidator : AbstractValidator<CreateCasePleasantFoodCommand>
{
    public CreateCasePleasantFoodCommandValidator()
    {
        RuleFor(x => x.CaseId)
            .NotNull().WithMessage("شناسه پرونده نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه پرونده نباید خالی باشد.");

        RuleFor(x => x.FoodId)
            .NotNull().WithMessage("شناسه غذا نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه غذا نباید خالی باشد.");


    }
}

