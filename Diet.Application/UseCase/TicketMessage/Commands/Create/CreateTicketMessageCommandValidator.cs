using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.TicketMessage.Create;
namespace Diet.Domain.UseCase.TicketMessage.Commands.Create
{
    public class CreateTicketMessageCommandValidator : AbstractValidator<CreateTicketMessageCommand>
    {
        public CreateTicketMessageCommandValidator()
        {

            RuleFor(x => x.TextMessage)
                .NotNull().WithMessage("متن پیام الزامی است.")
                .Length(1, 1000).WithMessage("متن پیام باید بین ۱ تا ۱۰۰۰ کاراکتر باشد.");

            RuleFor(x => x.FileName)
                .MaximumLength(255).WithMessage("نام فایل نباید بیشتر از ۲۵۵ کاراکتر باشد.");

            RuleFor(x => x.TicketId)
                .NotEmpty().WithMessage("شناسه تیکت نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.FromId)
                .NotEmpty().WithMessage("شناسه فرستنده نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
