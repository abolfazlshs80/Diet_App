

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateCasePleasantFoodCommandValidator : AbstractValidator<CreateCasePleasantFoodCommand>
{
    public CreateCasePleasantFoodCommandValidator()
    {

        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.FoodId).NotNull().NotEmpty();

    }
}

