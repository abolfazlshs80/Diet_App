using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Transactions.Delete;
namespace Diet.Domain.UseCase.Transactions.Commands.Create
{
    public class DeleteTransactionsCommandValidator : AbstractValidator<DeleteTransactionsCommand>
    {
        public DeleteTransactionsCommandValidator()
        {
            // Add validation rules here
        }
    }
}
