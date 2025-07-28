using Diet.Domain.transactions.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Transactions.GetById;

namespace Diet.Application.UseCase.Transactions.Queries.GetById;

public class GetByIdTransactionsQueryHandler : IQueryHandler<GetByIdTransactionsQuery, GetByIdTransactionsQueryResult>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdTransactionsQueryHandler(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _transactionsRepository = transactionsRepository;
    }

    public async Task<ErrorOr<GetByIdTransactionsQueryResult>> Handle(GetByIdTransactionsQuery query)
    {
        var result = await _transactionsRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Transactions not found");

        return new GetByIdTransactionsQueryResult(result.Id,result.TotalPrice,result.ZarinPalAuthority,result.ZarinPalRefNum, (int)result.TransactionType);
    }
}
