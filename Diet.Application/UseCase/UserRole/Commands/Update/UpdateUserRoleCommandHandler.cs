using Diet.Domain.Contract.Commands.UserRole.Update;
using Diet.Application.Interface;
using Diet.Domain.userRole.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.UserRole.Commands.Update;

public class UpdateUserRoleCommandHandler : ICommandHandler<UpdateUserRoleCommand, UpdateUserRoleCommandResult>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserRoleCommandHandler(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<ErrorOr<UpdateUserRoleCommandResult>> Handle(UpdateUserRoleCommand command)
    {
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
