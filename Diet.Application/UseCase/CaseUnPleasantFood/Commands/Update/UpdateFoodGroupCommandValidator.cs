

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseUnPleasantFoodCommandValidator : AbstractValidator<UpdateCaseUnPleasantFoodCommand>
{
    public UpdateCaseUnPleasantFoodCommandValidator()
    {
        RuleFor(x => x.CaseId).NotNull().NotEmpty();
        RuleFor(x => x.FoodId).NotNull().NotEmpty();
        RuleFor(x => x.Id).NotNull().NotEmpty();


    }
}

