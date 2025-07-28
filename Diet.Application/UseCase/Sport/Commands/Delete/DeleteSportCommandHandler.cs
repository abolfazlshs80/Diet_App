using Diet.Domain.sport.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Sport.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Sport.Commands.Delete;

public class DeleteSportCommandHandler : ICommandHandler<DeleteSportCommand, DeleteSportCommandResult>
{
    private readonly ISportRepository _SportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSportCommandHandler(ISportRepository SportRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _SportRepository = SportRepository;
    }

    public async Task<ErrorOr<DeleteSportCommandResult>> Handle(DeleteSportCommand command)
    {
        var result = await _SportRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteSportCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
        await _SportRepository.DeleteAsync(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteSportCommandResult("error", "delete Sport has error and rollback is done");

        return new DeleteSportCommandResult("success", "ok");
    }
}
