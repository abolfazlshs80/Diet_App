

using Diet.Domain.Contract.Commands.Order.Update;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateFoodFoodIntractionCommandValidator : AbstractValidator<UpdateFoodFoodIntractionCommand>
{
    public UpdateFoodFoodIntractionCommandValidator()
    {
        RuleFor(x => x.FoodFistId)  // اگر اشتباه تایپی است، لطفا اصلاح کنید به FoodFirstId
                 .NotNull().WithMessage("شناسه غذای اول نمی‌تواند تهی باشد.")
                 .NotEmpty().WithMessage("شناسه غذای اول نمی‌تواند خالی باشد.");

        RuleFor(x => x.FoodSecondId)
            .NotNull().WithMessage("شناسه غذای دوم نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه غذای دوم نمی‌تواند خالی باشد.");

        RuleFor(x => x.Id)
            .NotNull().WithMessage("شناسه رکورد نمی‌تواند تهی باشد.")
            .NotEmpty().WithMessage("شناسه رکورد نمی‌تواند خالی باشد.");
    }
}

