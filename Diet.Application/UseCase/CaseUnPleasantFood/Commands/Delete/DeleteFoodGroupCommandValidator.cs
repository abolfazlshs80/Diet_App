using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.CaseUnPleasantFood.Commands.Delete;

public class DeleteCaseUnPleasantFoodCommandValidator : AbstractValidator<DeleteCaseUnPleasantFoodCommand>
{
    public DeleteCaseUnPleasantFoodCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

