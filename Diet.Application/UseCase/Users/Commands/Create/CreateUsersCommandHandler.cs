using Diet.Application.Interface;
using Diet.Domain.user.Repository;
using Diet.Domain.Contract.Commands.Users.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Users.Commands.Create;

public class CreateUsersCommandHandler : ICommandHandler<CreateUsersCommand, CreateUsersCommandResult>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUsersCommandHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<CreateUsersCommandResult>> Handle(CreateUsersCommand command)
    {
        var result = Domain.user.User.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _usersRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateUsersCommandResult("error", "Add Users has error and rollback is done");

        return new CreateUsersCommandResult("success", "ok");
    }
}
