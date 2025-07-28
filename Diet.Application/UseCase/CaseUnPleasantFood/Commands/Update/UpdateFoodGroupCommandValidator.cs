

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseUnPleasantFoodCommandValidator : AbstractValidator<UpdateCaseUnPleasantFoodCommand>
{
    public UpdateCaseUnPleasantFoodCommandValidator()
    {
        RuleFor(x => x.CaseId)
         .NotNull().WithMessage("شناسه پرونده نمی‌تواند تهی باشد.")
         .NotEmpty().WithMessage("شناسه پرونده نمی‌تواند خالی باشد.");

        RuleFor(x => x.FoodId)
            .NotNull().WithMessage("شناسه غذا نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه غذا نمی‌تواند خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نمی‌تواند خالی باشد.");


    }
}

