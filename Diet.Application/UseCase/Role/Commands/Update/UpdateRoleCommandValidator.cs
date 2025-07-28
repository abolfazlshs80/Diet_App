using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Role.Update;
namespace Diet.Domain.UseCase.Role.Commands.Create
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty().WithMessage("شناسه نقش نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("نام نقش الزامی است.")
                .Length(2, 100).WithMessage("نام نقش باید بین ۲ تا ۱۰۰ کاراکتر باشد.");
        }
    }
}
