using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Create;
using Diet.Domain.disease.Repository;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.supplement.Repository;
using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Domain.supplementDurationAge.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.SupplementDurationAge.Commands.Create;

public class CreateSupplementDurationAgeCommandHandler : ICommandHandler<CreateSupplementDurationAgeCommand, CreateSupplementDurationAgeCommandResult>
{
    private readonly ISupplementDurationAgeRepository _supplementDurationAgeRepository;
    private readonly ISupplementRepository _supplementRepository;
    private readonly IDurationAgeRepository _durationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSupplementDurationAgeCommandHandler(ISupplementDurationAgeRepository supplementDurationAgeRepository,


        ISupplementRepository _supplementRepository  ,
        IDurationAgeRepository _durationAgeRepository
        , IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDurationAgeRepository = supplementDurationAgeRepository;
    }
 
    public async Task<ErrorOr<CreateSupplementDurationAgeCommandResult>> Handle(CreateSupplementDurationAgeCommand command)
    {

        if (!await _supplementRepository.IsExists(command.SupplementId))
            return new CreateSupplementDurationAgeCommandResult("error", "SupplementId is not Exists");
        if (!await _durationAgeRepository.IsExists(command.DurationAgeId))
            return new CreateSupplementDurationAgeCommandResult("error", "DurationAgeId is not Exists");

        var result = Domain.supplementDurationAge.SupplementDurationAge.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _supplementDurationAgeRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateSupplementDurationAgeCommandResult("error", "Add SupplementDurationAge has error and rollback is done");

        return new CreateSupplementDurationAgeCommandResult("success", "ok");
    }
}
