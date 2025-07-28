using FluentValidation;
using Diet.Domain.Contract.Queries.Transactions.GetAll;
namespace Diet.Application.UseCase.Transactions.Queries.GetAll;

public class GetAllTransactionsQueryValidator : AbstractValidator<GetAllTransactionsQuery>
{
    public GetAllTransactionsQueryValidator()
    {
        
    }
}
