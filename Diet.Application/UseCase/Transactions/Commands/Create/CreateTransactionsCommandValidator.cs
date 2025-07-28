using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Transactions.Create;
namespace Diet.Domain.UseCase.Transactions.Commands.Create
{
    public class CreateTransactionsCommandValidator : AbstractValidator<CreateTransactionsCommand>
    {
        public CreateTransactionsCommandValidator()
        {
            // Add validation rules here
        }
    }
}
