using Diet.Domain.userRole.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.UserRole.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.UserRole.Queries.GetAll;

public class GetAllUserRoleQueryHandler : IQueryHandler<GetAllUserRoleQuery, GetAllUserRoleQueryResult>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserRoleQueryHandler(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<ErrorOr<GetAllUserRoleQueryResult>> Handle(GetAllUserRoleQuery query)
    {
        var result = await _userRoleRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllUserRoleQueryResult(
            result.Count,
            result.Select(_ => new GetUserRoleItem(_.Id,_.RoleId,_.UserId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
