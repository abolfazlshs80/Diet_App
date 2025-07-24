using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.FoodFoodIntraction.Commands.Delete;

public class DeleteFoodFoodIntractionCommandValidator : AbstractValidator<DeleteFoodFoodIntractionCommand>
{
    public DeleteFoodFoodIntractionCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

