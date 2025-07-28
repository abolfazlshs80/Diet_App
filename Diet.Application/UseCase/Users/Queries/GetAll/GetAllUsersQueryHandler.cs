using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Users.GetAll;
using System.Linq;
using Diet.Domain.user.Repository;

namespace Diet.Application.UseCase.Users.Queries.GetAll;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, GetAllUsersQueryResult>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersQueryHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<GetAllUsersQueryResult>> Handle(GetAllUsersQuery query)
    {
        var result = await _usersRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllUsersQueryResult(
            result.Count,
            result.Select(_ => new GetUsersItem(_.Id,_.FirstName,_.LastName,_.ImageName,_.ReferenceCode,_.VerifyCode,_.CardNumber,_.ShbaNumber,_.VerifyExpire,_.Deleted,_.CreateDate,_.BirthDay, (int)_.Gender)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
