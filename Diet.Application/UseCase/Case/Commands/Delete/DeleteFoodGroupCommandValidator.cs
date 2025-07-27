using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.Case.Commands.Delete;

public class DeleteCaseCommandValidator : AbstractValidator<DeleteCaseCommand>
{
    public DeleteCaseCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

