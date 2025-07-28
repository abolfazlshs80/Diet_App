using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Users.Create;
namespace Diet.Domain.UseCase.Users.Commands.Create
{
    public class CreateUsersCommandValidator : AbstractValidator<CreateUsersCommand>
    {
        public CreateUsersCommandValidator()
        {

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("نام الزامی است.")
                .Length(2, 100).WithMessage("نام باید بین ۲ تا ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("نام خانوادگی الزامی است.")
                .Length(2, 100).WithMessage("نام خانوادگی باید بین ۲ تا ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.ImageName)
                .MaximumLength(255).WithMessage("نام تصویر نباید بیش از ۲۵۵ کاراکتر باشد.");

            RuleFor(x => x.ReferenceCode)
                .MaximumLength(50).WithMessage("کد مرجع نباید بیش از ۵۰ کاراکتر باشد.");

            RuleFor(x => x.VerifyCode)
                .MaximumLength(50).WithMessage("کد تایید نباید بیش از ۵۰ کاراکتر باشد.");

            RuleFor(x => x.CardNumber)
                .MaximumLength(30).WithMessage("شماره کارت نباید بیش از ۳۰ کاراکتر باشد.");

            RuleFor(x => x.ShbaNumber)
                .MaximumLength(34).WithMessage("شماره شبا نباید بیش از ۳۴ کاراکتر باشد.");

            RuleFor(x => x.VerifyExpire)
                .Must(date => !date.HasValue || date.Value > DateTime.MinValue)
                .WithMessage("تاریخ انقضای تایید نامعتبر است.");

            RuleFor(x => x.CreateDate)
                .NotEmpty().WithMessage("تاریخ ایجاد الزامی است.");

            RuleFor(x => x.BirthDay)
                .Must(date => !date.HasValue || date.Value <= DateTime.Now)
                .WithMessage("تاریخ تولد نمی‌تواند در آینده باشد.");

            RuleFor(x => x.Gender)
                .Must(g => !g.HasValue || (g.Value == 0 || g.Value == 1 || g.Value == 2))
                .WithMessage("جنسیت باید مقدار معتبر باشد (0: نامشخص، 1: مرد، 2: زن).");
        }
    }
}
