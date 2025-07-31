using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementDurationAge.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDurationAge.Commands.Update;

public class UpdateSupplementDurationAgeCommandHandler : ICommandHandler<UpdateSupplementDurationAgeCommand, UpdateSupplementDurationAgeCommandResult>
{
 
    private readonly ISupplementDurationAgeRepository _supplementDurationAgeRepository;
    private readonly ISupplementRepository _supplementRepository;
    private readonly IDurationAgeRepository _durationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSupplementDurationAgeCommandHandler(ISupplementDurationAgeRepository supplementDurationAgeRepository,


        ISupplementRepository _supplementRepository,
        IDurationAgeRepository _durationAgeRepository
        , IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDurationAgeRepository = supplementDurationAgeRepository;
    }
    public async Task<ErrorOr<UpdateSupplementDurationAgeCommandResult>> Handle(UpdateSupplementDurationAgeCommand command)
    {
        if (!await _supplementRepository.IsExists(command.SupplementId))
            return new UpdateSupplementDurationAgeCommandResult("error", "SupplementId is not Exists");
        if (!await _durationAgeRepository.IsExists(command.DurationAgeId))
            return new UpdateSupplementDurationAgeCommandResult("error", "DurationAgeId is not Exists");

        var supplementDurationAge = await _supplementDurationAgeRepository.ByIdAsync(command.Id);
        if (supplementDurationAge == null)
            return new UpdateSupplementDurationAgeCommandResult("error", "not found supplementdurationage");

        var result = Domain.supplementDurationAge.SupplementDurationAge.Update(supplementDurationAge, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _supplementDurationAgeRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSupplementDurationAgeCommandResult("error", "Update SupplementDurationAge has error and rollback is done");

        return new UpdateSupplementDurationAgeCommandResult("success", "ok");
    }
}
