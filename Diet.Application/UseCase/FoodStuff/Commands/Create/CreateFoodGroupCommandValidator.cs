

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodStuffCommandValidator : AbstractValidator<CreateFoodStuffCommand>
{
    public CreateFoodStuffCommandValidator()
    {

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان الزامی است.")
            .Length(2, 150).WithMessage("عنوان باید بین ۲ تا ۱۵۰ کاراکتر باشد.");
    }
}

