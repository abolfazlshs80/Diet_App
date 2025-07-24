

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
{
    public CreateFoodCommandValidator()
    {
        RuleFor(x => x.Title).Length(2, 150).WithMessage("Please  Enter a  name");
        RuleFor(x => x.Description).Length(2, 150).WithMessage("Please  Enter a  Description");
        RuleFor(x => x.Value).NotNull().WithMessage("Please  Enter a Value");
        RuleFor(x => x.FoodGroupId).NotNull().WithMessage("Please  Enter a FoodGroupId");

    }
}

