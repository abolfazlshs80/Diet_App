using Diet.Domain.Contract.Commands.Users.Update;
using Diet.Application.Interface;

using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.user.Repository;

namespace Diet.Application.UseCase.Users.Commands.Update;

public class UpdateUsersCommandHandler : ICommandHandler<UpdateUsersCommand, UpdateUsersCommandResult>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsersCommandHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<UpdateUsersCommandResult>> Handle(UpdateUsersCommand command)
    {
        var users = await _usersRepository.ByIdAsync(command.Id);
        if (users == null)
            return new UpdateUsersCommandResult("error", "not found users");

        var result = Domain.user.User.Update(users, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _usersRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateUsersCommandResult("error", "Update Users has error and rollback is done");

        return new UpdateUsersCommandResult("success", "ok");
    }
}
