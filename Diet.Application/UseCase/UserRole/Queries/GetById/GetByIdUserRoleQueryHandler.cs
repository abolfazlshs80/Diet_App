using Diet.Domain.userRole.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.UserRole.GetById;

namespace Diet.Application.UseCase.UserRole.Queries.GetById;

public class GetByIdUserRoleQueryHandler : IQueryHandler<GetByIdUserRoleQuery, GetByIdUserRoleQueryResult>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdUserRoleQueryHandler(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<ErrorOr<GetByIdUserRoleQueryResult>> Handle(GetByIdUserRoleQuery query)
    {
        var result = await _userRoleRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "UserRole not found");

        return new GetByIdUserRoleQueryResult(result.Id,result.RoleId,result.UserId);
    }
}
