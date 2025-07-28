

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
{
    public UpdateFoodCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه آیتم نباید تهی باشد.");

        RuleFor(x => x.Title)
            .NotNull().WithMessage("عنوان نباید خالی باشد.")
            .Length(2, 100).WithMessage("عنوان باید بین ۲ تا 100 کاراکتر باشد.");

        RuleFor(x => x.Description)
            .NotNull().WithMessage("توضیحات نباید خالی باشد.")
            .Length(2, 1000).WithMessage("توضیحات باید بین ۲ تا 1000 کاراکتر باشد.");

        RuleFor(x => x.Value)
            .NotNull().WithMessage("لطفاً مقدار را وارد کنید.");

        RuleFor(x => x.FoodGroupId)
            .NotNull().WithMessage("شناسه گروه غذایی نباید تهی باشد.");

    }
}

