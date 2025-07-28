

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodGroupCommandValidator : AbstractValidator<CreateFoodGroupCommand>
{
    public CreateFoodGroupCommandValidator()
    {


        RuleFor(x => x.Title)
            .NotNull().WithMessage("نام مشتری الزامی است.")
            .Length(2, 150).WithMessage("نام مشتری باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

