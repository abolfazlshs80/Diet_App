using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Transactions.Update;
namespace Diet.Domain.UseCase.Transactions.Commands.Create
{
    public class UpdateTransactionsCommandValidator : AbstractValidator<UpdateTransactionsCommand>
    {
        public UpdateTransactionsCommandValidator()
        {
            // Add validation rules here
        }
    }
}
