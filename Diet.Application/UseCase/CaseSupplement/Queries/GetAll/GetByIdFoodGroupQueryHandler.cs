using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseSupplement.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Application.Interface;
using Diet.Domain.CaseSupplement.Repository;
namespace Diet.Application.UseCase.CaseSupplement.Queries.GetAll;

public class GetAllCaseSupplementQueryHandler : IQueryHandler<GetAllCaseSupplementQuery,GetAllCaseSupplementQueryResult>
{
    private readonly ICaseSupplementRepository _CaseSupplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCaseSupplementQueryHandler(ICaseSupplementRepository CaseSupplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseSupplementRepository = CaseSupplementRepository;
    }


    public async Task<ErrorOr<GetAllCaseSupplementQueryResult>> Handle(GetAllCaseSupplementQuery Query)
    {
        var result = await _CaseSupplementRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCaseSupplementQueryResult(result.Count, result.Select(_ => new GetCaseSupplementItem(_.Id,_.CaseId,_.SupplementId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
