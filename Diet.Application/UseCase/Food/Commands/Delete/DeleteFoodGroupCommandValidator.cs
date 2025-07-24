using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.Food.Commands.Delete;

public class DeleteFoodCommandValidator : AbstractValidator<DeleteFoodCommand>
{
    public DeleteFoodCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

