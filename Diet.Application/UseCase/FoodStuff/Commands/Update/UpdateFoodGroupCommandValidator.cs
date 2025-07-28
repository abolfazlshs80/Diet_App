

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodStuffCommandValidator : AbstractValidator<UpdateFoodStuffCommand>
{
    public UpdateFoodStuffCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه نمی‌تواند تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان الزامی است.")
            .Length(2, 150).WithMessage("عنوان باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

    }
}

