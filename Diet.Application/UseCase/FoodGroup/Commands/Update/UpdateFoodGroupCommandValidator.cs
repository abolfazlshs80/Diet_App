

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodGroupCommandValidator : AbstractValidator<UpdateFoodGroupCommand>
{
    public UpdateFoodGroupCommandValidator()
    {

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("نام مشتری الزامی است.")
            .Length(2, 150).WithMessage("نام مشتری باید بین ۲ تا ۱۵۰ کاراکتر باشد.");
    }
}

