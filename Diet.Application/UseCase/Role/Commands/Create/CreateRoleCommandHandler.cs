using Diet.Application.Interface;
using Diet.Domain.role.Repository;
using Diet.Domain.Contract.Commands.Role.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Role.Commands.Create;

public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResult>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<CreateRoleCommandResult>> Handle(CreateRoleCommand command)
    {
        var result = Domain.role.Role.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _roleRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateRoleCommandResult("error", "Add Role has error and rollback is done");

        return new CreateRoleCommandResult("success", "ok");
    }
}
