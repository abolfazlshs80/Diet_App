using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Supplement.Update;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementGroup.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Supplement.Commands.Update;

public class UpdateSupplementCommandHandler : ICommandHandler<UpdateSupplementCommand, UpdateSupplementCommandResult>
{
    private readonly ISupplementRepository _supplementRepository;
    private readonly ISupplementGroupRepository _supplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSupplementCommandHandler(ISupplementRepository supplementRepository, ISupplementGroupRepository supplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementRepository = supplementRepository;
        _supplementGroupRepository = supplementGroupRepository;
    }

    public async Task<ErrorOr<UpdateSupplementCommandResult>> Handle(UpdateSupplementCommand command)
    {
        if (!await _supplementGroupRepository.IsExists(command.SupplementGroupId))
            return new UpdateSupplementCommandResult("error", "SupplementGroupId is not Exists");

        var supplement = await _supplementRepository.ByIdAsync(command.Id);
        if (supplement == null)
            return new UpdateSupplementCommandResult("error", "not found supplement");

        var result = Domain.supplement.Supplement.Update(supplement, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementCommandResult("error", "Update Supplement has error and rollback is done");

        return new UpdateSupplementCommandResult("success", "ok");
    }
}
