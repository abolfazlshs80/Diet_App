using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementGroup.Create;
namespace Diet.Domain.UseCase.SupplementGroup.Commands.Create
{
    public class CreateSupplementGroupCommandValidator : AbstractValidator<CreateSupplementGroupCommand>
    {
        public CreateSupplementGroupCommandValidator()
        {

            RuleFor(x => x.Title)
                .NotNull().WithMessage("عنوان گروه مکمل الزامی است.")
                .Length(2, 150).WithMessage("عنوان گروه مکمل باید بین ۲ تا ۱۵۰ کاراکتر باشد.");
        }
    }
}
