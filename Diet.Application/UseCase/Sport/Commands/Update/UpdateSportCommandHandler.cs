using Diet.Domain.Contract.Commands.Sport.Update;
using Diet.Application.Interface;
using Diet.Domain.sport.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Sport.Commands.Update;

public class UpdateSportCommandHandler : ICommandHandler<UpdateSportCommand, UpdateSportCommandResult>
{
    private readonly ISportRepository _sportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSportCommandHandler(ISportRepository sportRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _sportRepository = sportRepository;
    }

    public async Task<ErrorOr<UpdateSportCommandResult>> Handle(UpdateSportCommand command)
    {
        var sport = await _sportRepository.ByIdAsync(command.Id);
        if (sport == null)
            return new UpdateSportCommandResult("error", "not found sport");

        var result = Domain.sport.Sport.Update(sport, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _sportRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateSportCommandResult("error", "Update Sport has error and rollback is done");

        return new UpdateSportCommandResult("success", "ok");
    }
}
