

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseFoodStuffAllergyCommandValidator : AbstractValidator<UpdateCaseFoodStuffAllergyCommand>
{
    public UpdateCaseFoodStuffAllergyCommandValidator()
    {
        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.FoodStuffId).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();


    }
}

