

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCaseFoodStuffAllergyCommandValidator : AbstractValidator<CreateCaseFoodStuffAllergyCommand>
{
    public CreateCaseFoodStuffAllergyCommandValidator()
    {

        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.FoodStuffId).NotNull().NotEmpty();

    }
}

