

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodFoodIntractionCommandValidator : AbstractValidator<UpdateFoodFoodIntractionCommand>
{
    public UpdateFoodFoodIntractionCommandValidator()
    {
        RuleFor(x => x.FoodFistId).NotNull().NotEmpty();
        RuleFor(x => x.FoodSecondId).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();


    }
}

