

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCasePleasantFoodCommandValidator : AbstractValidator<UpdateCasePleasantFoodCommand>
{
    public UpdateCasePleasantFoodCommandValidator()
    {
        RuleFor(x => x.CaseId)
                .NotNull().WithMessage("شناسه پرونده نباید تهی باشد.")
                .NotEmpty().WithMessage("شناسه پرونده نباید خالی باشد.");

        RuleFor(x => x.FoodId)
            .NotNull().WithMessage("شناسه غذا نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه غذا نباید خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نباید تهی باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نباید خالی باشد.");
    }
}

