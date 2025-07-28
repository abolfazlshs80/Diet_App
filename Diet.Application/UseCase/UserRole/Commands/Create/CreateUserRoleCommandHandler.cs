using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.UserRole.Create;
using Diet.Domain.role.Repository;
using Diet.Domain.ticket.Repository;
using Diet.Domain.user.Repository;
using Diet.Domain.userRole.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.UserRole.Commands.Create;

public class CreateUserRoleCommandHandler : ICommandHandler<CreateUserRoleCommand, CreateUserRoleCommandResult>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;
    private readonly IUsersRepository _usersRepository;

    public CreateUserRoleCommandHandler(IUserRoleRepository userRoleRepository,

        IRoleRepository roleRepository  ,
        IUsersRepository usersRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRoleRepository = userRoleRepository;
        _usersRepository = usersRepository;
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<CreateUserRoleCommandResult>> Handle(CreateUserRoleCommand command)
    {
        if (!await _usersRepository.IsExists(command.UserId))
            return new CreateUserRoleCommandResult("error", "UserId is not Exists");
        if (!await _roleRepository.IsExists(command.RoleId))
            return new CreateUserRoleCommandResult("error", "RoleId is not Exists");

        var result = Domain.userRole.UserRole.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _userRoleRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateUserRoleCommandResult("error", "Add UserRole has error and rollback is done");

        return new CreateUserRoleCommandResult("success", "ok");
    }
}
