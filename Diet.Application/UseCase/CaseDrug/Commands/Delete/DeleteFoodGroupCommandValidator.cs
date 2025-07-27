using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.CaseDrug.Commands.Delete;

public class DeleteCaseDrugCommandValidator : AbstractValidator<DeleteCaseDrugCommand>
{
    public DeleteCaseDrugCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

