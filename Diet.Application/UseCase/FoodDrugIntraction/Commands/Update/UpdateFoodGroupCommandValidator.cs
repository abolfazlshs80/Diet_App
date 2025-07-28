

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodDrugIntractionCommandValidator : AbstractValidator<UpdateFoodDrugIntractionCommand>
{
    public UpdateFoodDrugIntractionCommandValidator()
    {
        RuleFor(x => x.FoodId)
          .NotNull().WithMessage("شناسه غذا نمی‌تواند تهی باشد.")
          .NotEmpty().WithMessage("شناسه غذا نمی‌تواند خالی باشد.");

        RuleFor(x => x.DrugId)
            .NotNull().WithMessage("شناسه دارو نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه دارو نمی‌تواند خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نمی‌تواند خالی باشد.");
    }
}

