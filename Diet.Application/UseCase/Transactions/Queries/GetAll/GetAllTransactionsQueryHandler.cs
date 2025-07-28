using Diet.Domain.transactions.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Transactions.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.Transactions.Queries.GetAll;

public class GetAllTransactionsQueryHandler : IQueryHandler<GetAllTransactionsQuery, GetAllTransactionsQueryResult>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTransactionsQueryHandler(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _transactionsRepository = transactionsRepository;
    }

    public async Task<ErrorOr<GetAllTransactionsQueryResult>> Handle(GetAllTransactionsQuery query)
    {
        var result = await _transactionsRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllTransactionsQueryResult(
            result.Count,
            result.Select(_ => new GetTransactionsItem(_.Id,_.TotalPrice,_.ZarinPalAuthority,_.ZarinPalRefNum, (int)_.TransactionType)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
