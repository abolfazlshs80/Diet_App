using FluentValidation;
using Diet.Domain.Contract.Queries.Transactions.GetById;
namespace Diet.Application.UseCase.Transactions.Queries.GetById;

public class GetByIdTransactionsQueryValidator : AbstractValidator<GetByIdTransactionsQuery>
{
    public GetByIdTransactionsQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
