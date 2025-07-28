using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Role.Create;
namespace Diet.Domain.UseCase.Role.Commands.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {

            RuleFor(x => x.Name)
                .NotNull().WithMessage("نام نقش الزامی است.")
                .Length(2, 100).WithMessage("نام نقش باید بین ۲ تا ۱۰۰ کاراکتر باشد.");
        }
    }
}
