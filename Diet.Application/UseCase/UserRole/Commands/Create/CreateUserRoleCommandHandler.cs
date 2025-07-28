using Diet.Application.Interface;
using Diet.Domain.userRole.Repository;
using Diet.Domain.Contract.Commands.UserRole.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.UserRole.Commands.Create;

public class CreateUserRoleCommandHandler : ICommandHandler<CreateUserRoleCommand, CreateUserRoleCommandResult>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserRoleCommandHandler(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<ErrorOr<CreateUserRoleCommandResult>> Handle(CreateUserRoleCommand command)
    {
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
