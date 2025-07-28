using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.TicketMessage.Update;
using Diet.Domain.ticket.Repository;
using Diet.Domain.ticketMessage.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.TicketMessage.Commands.Update;

public class UpdateTicketMessageCommandHandler : ICommandHandler<UpdateTicketMessageCommand, UpdateTicketMessageCommandResult>
{
    private readonly ITicketMessageRepository _ticketMessageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _usersRepository;
    private readonly ITicketRepository _ticketRepository;

    public UpdateTicketMessageCommandHandler(ITicketMessageRepository ticketMessageRepository,
        IUsersRepository usersRepository,
        ITicketRepository ticketRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketMessageRepository = ticketMessageRepository;

        _ticketRepository = ticketRepository;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<UpdateTicketMessageCommandResult>> Handle(UpdateTicketMessageCommand command)
    {
        if (!await _ticketRepository.IsExists(command.TicketId))
            return new UpdateTicketMessageCommandResult("error", "TicketId is not Exists");
        if (!await _usersRepository.IsExists(command.FromId))
            return new UpdateTicketMessageCommandResult("error", "UserId is not Exists");

        var ticketMessage = await _ticketMessageRepository.ByIdAsync(command.Id);
        if (ticketMessage == null)
            return new UpdateTicketMessageCommandResult("error", "not found ticketmessage");

        var result = Domain.ticketMessage.TicketMessage.Update(ticketMessage, command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _ticketMessageRepository.UpdateAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();
        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new UpdateTicketMessageCommandResult("error", "Update TicketMessage has error and rollback is done");

        return new UpdateTicketMessageCommandResult("success", "ok");
    }
}
