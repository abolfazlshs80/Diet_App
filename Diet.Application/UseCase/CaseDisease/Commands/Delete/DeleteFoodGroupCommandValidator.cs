using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.CaseDisease.Commands.Delete;

public class DeleteCaseDiseaseCommandValidator : AbstractValidator<DeleteCaseDiseaseCommand>
{
    public DeleteCaseDiseaseCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

