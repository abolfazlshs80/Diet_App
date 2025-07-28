using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementGroup.Update;
namespace Diet.Domain.UseCase.SupplementGroup.Commands.Create
{
    public class UpdateSupplementGroupCommandValidator : AbstractValidator<UpdateSupplementGroupCommand>
    {
        public UpdateSupplementGroupCommandValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.Title)
                .NotNull().WithMessage("عنوان گروه مکمل الزامی است.")
                .Length(2, 150).WithMessage("عنوان گروه مکمل باید بین ۲ تا ۱۵۰ کاراکتر باشد.");
        }
    }
}
