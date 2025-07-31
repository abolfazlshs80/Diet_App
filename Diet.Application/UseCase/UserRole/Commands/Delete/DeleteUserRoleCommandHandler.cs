using Diet.Domain.userRole.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.UserRole.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.UserRole.Commands.Delete;

public class DeleteUserRoleCommandHandler : ICommandHandler<DeleteUserRoleCommand, DeleteUserRoleCommandResult>
{
    private readonly IUserRoleRepository _UserRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserRoleCommandHandler(IUserRoleRepository UserRoleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _UserRoleRepository = UserRoleRepository;
    }

    public async Task<ErrorOr<DeleteUserRoleCommandResult>> Handle(DeleteUserRoleCommand command)
    {
        var result = await _UserRoleRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteUserRoleCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _UserRoleRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteUserRoleCommandResult("error", "delete UserRole has error and rollback is done");

        return new DeleteUserRoleCommandResult("success", "ok");
    }
}
