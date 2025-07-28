using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Transactions.Update;
namespace Diet.Domain.UseCase.Transactions.Commands.Create
{
    public class UpdateTransactionsCommandValidator : AbstractValidator<UpdateTransactionsCommand>
    {
        public UpdateTransactionsCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("شناسه تراکنش نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

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
