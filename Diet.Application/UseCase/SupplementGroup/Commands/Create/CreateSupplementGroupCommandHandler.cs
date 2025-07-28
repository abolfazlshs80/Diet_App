using Diet.Application.Interface;
using Diet.Domain.supplementGroup.Repository;
using Diet.Domain.Contract.Commands.SupplementGroup.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementGroup.Commands.Create;

public class CreateSupplementGroupCommandHandler : ICommandHandler<CreateSupplementGroupCommand, CreateSupplementGroupCommandResult>
{
    private readonly ISupplementGroupRepository _supplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementGroupCommandHandler(ISupplementGroupRepository supplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementGroupRepository = supplementGroupRepository;
    }

    public async Task<ErrorOr<CreateSupplementGroupCommandResult>> Handle(CreateSupplementGroupCommand command)
    {
        var result = Domain.supplementGroup.SupplementGroup.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementGroupRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSupplementGroupCommandResult("error", "Add SupplementGroup has error and rollback is done");

        return new CreateSupplementGroupCommandResult("success", "ok");
    }
}
