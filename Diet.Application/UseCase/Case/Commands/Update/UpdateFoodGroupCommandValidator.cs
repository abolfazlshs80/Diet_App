

using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Enums;
using FluentValidation;

namespace Order.Application.UseCase.Order.Commands.Update;

public class UpdateCaseCommandValidator : AbstractValidator<UpdateCaseCommand>
{
    public UpdateCaseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("شناسه مورد (Case) الزامی است");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("وزن باید بزرگتر از صفر باشد");

        RuleFor(x => x.Height)
            .GreaterThan(0).WithMessage("قد باید بزرگتر از صفر باشد");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("تاریخ تولد الزامی است");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("توضیحات نباید بیشتر از 1000 کاراکتر باشد");

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("جنسیت معتبر نیست");

        RuleFor(x => x.BodyActivity)
            .IsInEnum().WithMessage("میزان فعالیت بدنی معتبر نیست");

        RuleFor(x => x.ExerciseTime)
            .GreaterThanOrEqualTo(0).WithMessage("زمان ورزش نمی‌تواند منفی باشد");

        RuleFor(x => x.WeightChangeAmount)
            .InclusiveBetween(0, 4)
            //.When(x => x.ChangeWeightType == WeightChangeType.Decrease)
            .WithMessage("در صورت کاهش وزن، مقدار آن نباید بیش از ۴ کیلو باشد");

        RuleFor(x => x.DateOfStart)
            .GreaterThan(DateTime.MinValue).WithMessage("تاریخ شروع برنامه معتبر نیست");

        RuleFor(x => x.LifeCourseId)
            .NotEmpty().WithMessage("شناسه دوره زندگی الزامی است");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("شناسه کاربر الزامی است");

        RuleFor(x => x.TransactionId)
            .NotEmpty().WithMessage("شناسه تراکنش الزامی است");
    }
}
