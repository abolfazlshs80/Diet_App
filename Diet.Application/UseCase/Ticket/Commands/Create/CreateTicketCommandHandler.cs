using Diet.Application.Interface;
using Diet.Domain.ticket.Repository;
using Diet.Domain.Contract.Commands.Ticket.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.Ticket.Commands.Create;

public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, CreateTicketCommandResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<CreateTicketCommandResult>> Handle(CreateTicketCommand command)
    {
        var result = Domain.ticket.Ticket.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _ticketRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateTicketCommandResult("error", "Add Ticket has error and rollback is done");

        return new CreateTicketCommandResult("success", "ok");
    }
}
