using Diet.Domain.role.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Role.GetById;

namespace Diet.Application.UseCase.Role.Queries.GetById;

public class GetByIdRoleQueryHandler : IQueryHandler<GetByIdRoleQuery, GetByIdRoleQueryResult>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdRoleQueryHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<GetByIdRoleQueryResult>> Handle(GetByIdRoleQuery query)
    {
        var result = await _roleRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Role not found");

        return new GetByIdRoleQueryResult(result.Id,result.Name);
    }
}
