using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.Disease.Commands.Delete;

public class DeleteDiseaseCommandValidator : AbstractValidator<DeleteDiseaseCommand>
{
    public DeleteDiseaseCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

