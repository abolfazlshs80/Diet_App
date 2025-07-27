using Diet.Domain.Contract.Commands.Order.Delete;
using FluentValidation;

namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Commands.Delete;

public class DeleteCaseFoodStuffAllergyCommandValidator : AbstractValidator<DeleteCaseFoodStuffAllergyCommand>
{
    public DeleteCaseFoodStuffAllergyCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

