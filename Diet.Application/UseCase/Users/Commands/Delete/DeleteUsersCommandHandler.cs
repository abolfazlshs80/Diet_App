using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Users.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Users.Commands.Delete;

public class DeleteUsersCommandHandler : ICommandHandler<DeleteUsersCommand, DeleteUsersCommandResult>
{
    private readonly IUsersRepository _UsersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUsersCommandHandler(IUsersRepository UsersRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _UsersRepository = UsersRepository;
    }

    public async Task<ErrorOr<DeleteUsersCommandResult>> Handle(DeleteUsersCommand command)
    {
        var result = await _UsersRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteUsersCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
        await _UsersRepository.DeleteAsync(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteUsersCommandResult("error", "delete Users has error and rollback is done");

        return new DeleteUsersCommandResult("success", "ok");
    }
}
