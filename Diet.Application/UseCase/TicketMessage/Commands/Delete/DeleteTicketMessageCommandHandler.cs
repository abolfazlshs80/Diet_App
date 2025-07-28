using Diet.Domain.ticketMessage.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.TicketMessage.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.TicketMessage.Commands.Delete;

public class DeleteTicketMessageCommandHandler : ICommandHandler<DeleteTicketMessageCommand, DeleteTicketMessageCommandResult>
{
    private readonly ITicketMessageRepository _TicketMessageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketMessageCommandHandler(ITicketMessageRepository TicketMessageRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _TicketMessageRepository = TicketMessageRepository;
    }

    public async Task<ErrorOr<DeleteTicketMessageCommandResult>> Handle(DeleteTicketMessageCommand command)
    {
        var result = await _TicketMessageRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteTicketMessageCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
        await _TicketMessageRepository.DeleteAsync(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteTicketMessageCommandResult("error", "delete TicketMessage has error and rollback is done");

        return new DeleteTicketMessageCommandResult("success", "ok");
    }
}
