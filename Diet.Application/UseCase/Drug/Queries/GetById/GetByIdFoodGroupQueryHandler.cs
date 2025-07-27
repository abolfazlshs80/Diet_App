using Diet.Application.Interface;
using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Drug.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Diet.Framework.Core.Errors.BusErrors;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Drug.Queries.GetById;

public class GetByIdDrugQueryHandler : IQueryHandler<GetByIdDrugQuery, GetByIdDrugQueryResult>
{
    private readonly IDrugRepository _drugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdDrugQueryHandler(IDrugRepository DrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _drugRepository = DrugRepository;
    }


    public async Task<ErrorOr<GetByIdDrugQueryResult>> Handle(GetByIdDrugQuery query)
    {
        var result = await _drugRepository.ByIdAsync(query.Id);
        if (result == null)
            return Error.NotFound("NotFound", "Drug not found");

        return new GetByIdDrugQueryResult(result.Id, result.Title, result.Description);
    }
}
