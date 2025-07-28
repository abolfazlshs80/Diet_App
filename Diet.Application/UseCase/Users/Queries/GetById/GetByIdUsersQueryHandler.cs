using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Users.GetById;
using Diet.Domain.user.Repository;

namespace Diet.Application.UseCase.Users.Queries.GetById;

public class GetByIdUsersQueryHandler : IQueryHandler<GetByIdUsersQuery, GetByIdUsersQueryResult>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdUsersQueryHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<GetByIdUsersQueryResult>> Handle(GetByIdUsersQuery query)
    {
        var result = await _usersRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Users not found");

        return new GetByIdUsersQueryResult(result.Id,result.FirstName,result.LastName,result.ImageName,result.ReferenceCode,result.VerifyCode,result.CardNumber,result.ShbaNumber,result.VerifyExpire,result.Deleted,result.CreateDate,result.BirthDay, (int)result.Gender.Value);
    }
}
