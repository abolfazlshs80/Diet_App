

using Diet.Domain.Contract.Commands.Order.Create;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Create;

public class CreateFoodFoodIntractionCommandValidator : AbstractValidator<CreateFoodFoodIntractionCommand>
{
    public CreateFoodFoodIntractionCommandValidator()
    {
        RuleFor(x => x.FoodFistId)  // اگر اشتباه تایپی است، لطفا اصلاح کنید به FoodFirstId
             .NotNull().WithMessage("شناسه غذای اول نمی‌تواند تهی باشد.")
             .NotEmpty().WithMessage("شناسه غذای اول نمی‌تواند خالی باشد.");

        RuleFor(x => x.FoodSecondId)
            .NotNull().WithMessage("شناسه غذای دوم نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه غذای دوم نمی‌تواند خالی باشد.");

    }
}

