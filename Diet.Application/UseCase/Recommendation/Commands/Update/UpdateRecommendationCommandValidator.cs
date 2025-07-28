using Diet;
using Diet.Domain.Contract.Commands.Recommendation.Update;
using FluentValidation;
namespace Diet.Domain.UseCase.Recommendation.Commands.Create
{
    public class UpdateRecommendationCommandValidator : AbstractValidator<UpdateRecommendationCommand>
    {
        public UpdateRecommendationCommandValidator()
        {
            // Add validation rules here

            RuleFor(x => x.Id)
        .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.Title)
                .NotNull().WithMessage("عنوان فارسی الزامی است.")
                .Length(2, 150).WithMessage("عنوان فارسی باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

            RuleFor(x => x.EnglishTitle)
                .NotNull().WithMessage("عنوان انگلیسی الزامی است.")
                .Length(2, 150).WithMessage("عنوان انگلیسی باید بین ۲ تا ۱۵۰ کاراکتر باشد.");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("توضیحات الزامی است.")
                .Length(2, 500).WithMessage("توضیحات باید بین ۲ تا ۵۰۰ کاراکتر باشد.");

            RuleFor(x => x.HowToUse)
                .NotNull().WithMessage("نحوه استفاده الزامی است.")
                .Length(2, 500).WithMessage("نحوه استفاده باید بین ۲ تا ۵۰۰ کاراکتر باشد.");
        }
    }
}
