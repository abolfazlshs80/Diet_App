using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.UserRole.Update;
using Diet.Domain.role.Repository;
using Diet.Domain.user.Repository;
using Diet.Domain.userRole.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.UserRole.Commands.Update;

public class UpdateUserRoleCommandHandler : ICommandHandler<UpdateUserRoleCommand, UpdateUserRoleCommandResult>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;
    private readonly IUsersRepository _usersRepository;

    public UpdateUserRoleCommandHandler(IUserRoleRepository userRoleRepository,

        IRoleRepository roleRepository,
        IUsersRepository usersRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRoleRepository = userRoleRepository;
        _usersRepository = usersRepository;
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<UpdateUserRoleCommandResult>> Handle(UpdateUserRoleCommand command)
    {
        if (!await _usersRepository.IsExists(command.UserId))
            return new UpdateUserRoleCommandResult("error", "UserId is not Exists");
        if (!await _roleRepository.IsExists(command.RoleId))
            return new UpdateUserRoleCommandResult("error", "RoleId is not Exists");

        var userRole = await _userRoleRepository.ByIdAsync(command.Id);
        if (userRole == null)
            return new UpdateUserRoleCommandResult("error", "not found userrole");

        var result = Domain.userRole.UserRole.Update(userRole, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _userRoleRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateUserRoleCommandResult("error", "Update UserRole has error and rollback is done");

        return new UpdateUserRoleCommandResult("success", "ok");
    }
}
