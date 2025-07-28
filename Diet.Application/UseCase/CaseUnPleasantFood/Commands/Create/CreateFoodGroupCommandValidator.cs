

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseUnPleasantFoodCommandValidator : AbstractValidator<CreateCaseUnPleasantFoodCommand>
{
    public CreateCaseUnPleasantFoodCommandValidator()
    {

        RuleFor(x => x.CaseId)
               .NotNull().WithMessage("شناسه پرونده نمی‌تواند تهی باشد.")
               .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.FoodId)
            .NotNull().WithMessage("شناسه غذا نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه غذا نمی‌تواند خالی باشد.");


    }
}

