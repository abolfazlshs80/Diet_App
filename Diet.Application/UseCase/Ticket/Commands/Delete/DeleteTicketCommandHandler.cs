using Diet.Domain.ticket.Repository;
using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Ticket.Delete;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Ticket.Commands.Delete;

public class DeleteTicketCommandHandler : ICommandHandler<DeleteTicketCommand, DeleteTicketCommandResult>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketCommandHandler(ITicketRepository TicketRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _TicketRepository = TicketRepository;
    }

    public async Task<ErrorOr<DeleteTicketCommandResult>> Handle(DeleteTicketCommand command)
    {
        var result = await _TicketRepository.ByIdAsync(command.Id);
        if (result == null)
            return new DeleteTicketCommandResult("error", "notfound");

        await _unitOfWork.BeginTransactionAsync();
         _TicketRepository.Delete(result);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new DeleteTicketCommandResult("error", "delete Ticket has error and rollback is done");

        return new DeleteTicketCommandResult("success", "ok");
    }
}
