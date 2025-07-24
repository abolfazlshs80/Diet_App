using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.Drug.Commands.Delete;

public class DeleteDrugCommandValidator : AbstractValidator<DeleteDrugCommand>
{
    public DeleteDrugCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

