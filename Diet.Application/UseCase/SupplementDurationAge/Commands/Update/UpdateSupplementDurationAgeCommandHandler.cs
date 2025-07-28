using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
using Diet.Application.Interface;
using Diet.Domain.supplementDurationAge.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDurationAge.Commands.Update;

public class UpdateSupplementDurationAgeCommandHandler : ICommandHandler<UpdateSupplementDurationAgeCommand, UpdateSupplementDurationAgeCommandResult>
{
    private readonly ISupplementDurationAgeRepository _supplementDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSupplementDurationAgeCommandHandler(ISupplementDurationAgeRepository supplementDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDurationAgeRepository = supplementDurationAgeRepository;
    }

    public async Task<ErrorOr<UpdateSupplementDurationAgeCommandResult>> Handle(UpdateSupplementDurationAgeCommand command)
    {
        var supplementDurationAge = await _supplementDurationAgeRepository.ByIdAsync(command.Id);
        if (supplementDurationAge == null)
            return new UpdateSupplementDurationAgeCommandResult("error", "not found supplementdurationage");

        var result = Domain.supplementDurationAge.SupplementDurationAge.Update(supplementDurationAge, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementDurationAgeRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementDurationAgeCommandResult("error", "Update SupplementDurationAge has error and rollback is done");

        return new UpdateSupplementDurationAgeCommandResult("success", "ok");
    }
}
