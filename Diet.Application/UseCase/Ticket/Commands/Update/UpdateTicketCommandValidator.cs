using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Ticket.Update;
namespace Diet.Domain.UseCase.Ticket.Commands.Create
{
    public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        public UpdateTicketCommandValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty().WithMessage("شناسه تیکت نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.Title)
                .NotNull().WithMessage("عنوان تیکت الزامی است.")
                .Length(2, 200).WithMessage("عنوان تیکت باید بین ۲ تا ۲۰۰ کاراکتر باشد.");

            RuleFor(x => x.Number)
                .NotNull().WithMessage("شماره تیکت الزامی است.")
                .Length(1, 50).WithMessage("شماره تیکت باید بین ۱ تا ۵۰ کاراکتر باشد.");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("اولویت تیکت نامعتبر است.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("وضعیت تیکت نامعتبر است.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("شناسه کاربر نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
