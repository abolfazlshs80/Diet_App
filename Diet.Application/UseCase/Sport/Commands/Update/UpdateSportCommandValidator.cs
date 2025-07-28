using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Sport.Update;
namespace Diet.Domain.UseCase.Sport.Commands.Create
{
    public class UpdateSportCommandValidator : AbstractValidator<UpdateSportCommand>
    {
        public UpdateSportCommandValidator()
        {
            RuleFor(x => x.Id)
                   .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("نام ورزش الزامی است.")
                .Length(2, 100).WithMessage("نام ورزش باید بین ۲ تا ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.Low)
                .GreaterThanOrEqualTo(0).WithMessage("مقدار سطح پایین باید صفر یا بیشتر باشد.");

            RuleFor(x => x.Medium)
                .GreaterThanOrEqualTo(0).WithMessage("مقدار سطح متوسط باید صفر یا بیشتر باشد.");

            RuleFor(x => x.High)
                .GreaterThanOrEqualTo(0).WithMessage("مقدار سطح بالا باید صفر یا بیشتر باشد.");
        }
    }
}
