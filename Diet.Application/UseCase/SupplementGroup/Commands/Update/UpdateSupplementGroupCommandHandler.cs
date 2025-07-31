using Diet.Domain.Contract.Commands.SupplementGroup.Update;
using Diet.Application.Interface;
using Diet.Domain.supplementGroup.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementGroup.Commands.Update;

public class UpdateSupplementGroupCommandHandler : ICommandHandler<UpdateSupplementGroupCommand, UpdateSupplementGroupCommandResult>
{
    private readonly ISupplementGroupRepository _supplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSupplementGroupCommandHandler(ISupplementGroupRepository supplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementGroupRepository = supplementGroupRepository;
    }

    public async Task<ErrorOr<UpdateSupplementGroupCommandResult>> Handle(UpdateSupplementGroupCommand command)
    {
        var supplementGroup = await _supplementGroupRepository.ByIdAsync(command.Id);
        if (supplementGroup == null)
            return new UpdateSupplementGroupCommandResult("error", "not found supplementgroup");

        var result = Domain.supplementGroup.SupplementGroup.Update(supplementGroup, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _supplementGroupRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementGroupCommandResult("error", "Update SupplementGroup has error and rollback is done");

        return new UpdateSupplementGroupCommandResult("success", "ok");
    }
}
