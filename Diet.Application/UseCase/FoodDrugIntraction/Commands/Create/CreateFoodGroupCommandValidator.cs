

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodDrugIntractionCommandValidator : AbstractValidator<CreateFoodDrugIntractionCommand>
{
    public CreateFoodDrugIntractionCommandValidator()
    {
        RuleFor(x => x.FoodId)
               .NotNull().WithMessage("شناسه غذا نمی‌تواند تهی باشد.")
               .NotEmpty().WithMessage("شناسه غذا نمی‌تواند خالی باشد.");

        RuleFor(x => x.DrugId)
            .NotNull().WithMessage("شناسه دارو نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه دارو نمی‌تواند خالی باشد.");

    }
}

