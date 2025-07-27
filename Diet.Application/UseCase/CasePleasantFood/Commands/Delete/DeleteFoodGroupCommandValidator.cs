using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.CasePleasantFood.Commands.Delete;

public class DeleteCasePleasantFoodCommandValidator : AbstractValidator<DeleteCasePleasantFoodCommand>
{
    public DeleteCasePleasantFoodCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

