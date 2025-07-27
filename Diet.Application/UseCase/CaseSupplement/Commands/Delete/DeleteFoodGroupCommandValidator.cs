using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.CaseSupplement.Commands.Delete;

public class DeleteCaseSupplementCommandValidator : AbstractValidator<DeleteCaseSupplementCommand>
{
    public DeleteCaseSupplementCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

