

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodFoodIntractionCommandValidator : AbstractValidator<CreateFoodFoodIntractionCommand>
{
    public CreateFoodFoodIntractionCommandValidator()
    {
        RuleFor(x => x.FoodFistId).NotNull().NotEmpty();
        RuleFor(x => x.FoodSecondId).NotNull().NotEmpty();
       

    }
}

