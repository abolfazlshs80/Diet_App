using Diet.Domain.Contract.Commands.Role.Update;
using Diet.Application.Interface;
using Diet.Domain.role.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Role.Commands.Update;

public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, UpdateRoleCommandResult>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<UpdateRoleCommandResult>> Handle(UpdateRoleCommand command)
    {
        var role = await _roleRepository.ByIdAsync(command.Id);
        if (role == null)
            return new UpdateRoleCommandResult("error", "not found role");

        var result = Domain.role.Role.Update(role, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _roleRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateRoleCommandResult("error", "Update Role has error and rollback is done");

        return new UpdateRoleCommandResult("success", "ok");
    }
}
