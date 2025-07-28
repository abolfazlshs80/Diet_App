using Diet.Domain.Contract.Commands.Ticket.Update;
using Diet.Application.Interface;
using Diet.Domain.ticket.Repository;

using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Ticket.Commands.Update;

public class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand, UpdateTicketCommandResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<UpdateTicketCommandResult>> Handle(UpdateTicketCommand command)
    {
        var ticket = await _ticketRepository.ByIdAsync(command.Id);
        if (ticket == null)
            return new UpdateTicketCommandResult("error", "not found ticket");

        var result = Domain.ticket.Ticket.Update(ticket, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _ticketRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateTicketCommandResult("error", "Update Ticket has error and rollback is done");

        return new UpdateTicketCommandResult("success", "ok");
    }
}
