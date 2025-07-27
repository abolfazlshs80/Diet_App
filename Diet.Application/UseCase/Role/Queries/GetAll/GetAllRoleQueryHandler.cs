using Diet.Domain.role.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Role.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.Role.Queries.GetAll;

public class GetAllRoleQueryHandler : IQueryHandler<GetAllRoleQuery, GetAllRoleQueryResult>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRoleQueryHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<GetAllRoleQueryResult>> Handle(GetAllRoleQuery query)
    {
        var result = await _roleRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllRoleQueryResult(
            result.Count,
            result.Select(_ => new GetRoleItem(_.Id,_.Name)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
