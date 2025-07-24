

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodStuffCommandValidator : AbstractValidator<UpdateFoodStuffCommand>
{
    public UpdateFoodStuffCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Title).Length(2, 150).WithMessage("Please  Enter a title");

    }
}

