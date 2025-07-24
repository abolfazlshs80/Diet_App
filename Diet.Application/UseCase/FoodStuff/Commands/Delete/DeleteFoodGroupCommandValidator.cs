using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.FoodStuff.Commands.Delete;

public class DeleteFoodStuffCommandValidator : AbstractValidator<DeleteFoodStuffCommand>
{
    public DeleteFoodStuffCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

