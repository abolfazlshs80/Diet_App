using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.UserRole.Create;
namespace Diet.Domain.UseCase.UserRole.Commands.Create
{
    public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("شناسه نقش نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("شناسه کاربر نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
