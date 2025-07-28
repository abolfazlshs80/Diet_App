using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.UserRole.Update;
namespace Diet.Domain.UseCase.UserRole.Commands.Create
{
    public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleCommandValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("شناسه نقش نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("شناسه کاربر نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
