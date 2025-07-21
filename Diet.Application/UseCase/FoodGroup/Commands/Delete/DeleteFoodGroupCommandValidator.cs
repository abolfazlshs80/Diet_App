using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.FoodGroup.Commands.Delete;

public class DeleteFoodGroupCommandValidator : AbstractValidator<DeleteFoodGroupCommand>
{
    public DeleteFoodGroupCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

