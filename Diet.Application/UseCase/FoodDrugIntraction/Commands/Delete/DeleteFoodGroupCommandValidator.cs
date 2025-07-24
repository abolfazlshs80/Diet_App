using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.FoodDrugIntraction.Commands.Delete;

public class DeleteFoodDrugIntractionCommandValidator : AbstractValidator<DeleteFoodDrugIntractionCommand>
{
    public DeleteFoodDrugIntractionCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

