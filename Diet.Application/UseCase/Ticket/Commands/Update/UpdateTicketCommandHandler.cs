using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Ticket.Update;
using Diet.Domain.ticket.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Ticket.Commands.Update;

public class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand, UpdateTicketCommandResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<UpdateTicketCommandResult>> Handle(UpdateTicketCommand command)
    {
        if (!await _usersRepository.IsExists(command.UserId))
            return new UpdateTicketCommandResult("error", "UserId is not Exists");

        var ticket = await _ticketRepository.ByIdAsync(command.Id);
        if (ticket == null)
            return new UpdateTicketCommandResult("error", "not found ticket");

        var result = Domain.ticket.Ticket.Update(ticket, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
         _ticketRepository.Update(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateTicketCommandResult("error", "Update Ticket has error and rollback is done");

        return new UpdateTicketCommandResult("success", "ok");
    }
}
