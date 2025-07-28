using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Transactions.Create;
namespace Diet.Domain.UseCase.Transactions.Commands.Create
{
    public class CreateTransactionsCommandValidator : AbstractValidator<CreateTransactionsCommand>
    {
        public CreateTransactionsCommandValidator()
        {

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("مبلغ کل باید بزرگتر از صفر باشد.");

            RuleFor(x => x.ZarinPalAuthority)
                .NotNull().WithMessage("کد مرجع زرین‌پال الزامی است.")
                .Length(1, 100).WithMessage("کد مرجع زرین‌پال باید بین ۱ تا ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.ZarinPalRefNum)
                .NotNull().WithMessage("شماره مرجع زرین‌پال الزامی است.")
                .Length(1, 100).WithMessage("شماره مرجع زرین‌پال باید بین ۱ تا ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.TransactionType)
                .IsInEnum().WithMessage("نوع تراکنش نامعتبر است.");
        }
    }
}
