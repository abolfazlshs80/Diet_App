using Diet.Domain.role.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Role.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Role.Commands.Delete;

public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResult>
{
    private readonly IRoleRepository _RoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleCommandHandler(IRoleRepository RoleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _RoleRepository = RoleRepository;
    }

    public async Task<ErrorOr<DeleteRoleCommandResult>> Handle(DeleteRoleCommand command)
    {
        var result = await _RoleRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteRoleCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _RoleRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteRoleCommandResult("error", "delete Role has error and rollback is done");

        return new DeleteRoleCommandResult("success", "ok");
    }
}
