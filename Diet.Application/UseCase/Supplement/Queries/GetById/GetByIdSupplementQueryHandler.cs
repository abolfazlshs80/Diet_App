using Diet.Domain.supplement.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Supplement.GetById;

namespace Diet.Application.UseCase.Supplement.Queries.GetById;

public class GetByIdSupplementQueryHandler : IQueryHandler<GetByIdSupplementQuery, GetByIdSupplementQueryResult>
{
    private readonly ISupplementRepository _supplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdSupplementQueryHandler(ISupplementRepository supplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementRepository = supplementRepository;
    }

    public async Task<ErrorOr<GetByIdSupplementQueryResult>> Handle(GetByIdSupplementQuery query)
    {
        var result = await _supplementRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Supplement not found");

        return new GetByIdSupplementQueryResult(result.Id,result.Title,result.EnglishTitle,result.Description,result.HowToUse,result.SupplementGroupId);
    }
}
