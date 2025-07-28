using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.TicketMessage.Create;
using Diet.Domain.supplement.Repository;
using Diet.Domain.ticket.Repository;
using Diet.Domain.ticketMessage.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.TicketMessage.Commands.Create;

public class CreateTicketMessageCommandHandler : ICommandHandler<CreateTicketMessageCommand, CreateTicketMessageCommandResult>
{
    private readonly ITicketMessageRepository _ticketMessageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _usersRepository;
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketMessageCommandHandler(ITicketMessageRepository ticketMessageRepository,
        IUsersRepository usersRepository  ,
        ITicketRepository ticketRepository,


        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketMessageRepository = ticketMessageRepository;

        _ticketRepository = ticketRepository;
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<CreateTicketMessageCommandResult>> Handle(CreateTicketMessageCommand command)
    {
        if (!await _ticketRepository.IsExists(command.TicketId))
            return new CreateTicketMessageCommandResult("error", "TicketId is not Exists");
        if (!await _usersRepository.IsExists(command.FromId))
            return new CreateTicketMessageCommandResult("error", "UserId is not Exists");

        var result = Domain.ticketMessage.TicketMessage.Create(command);
        if (result.IsError)
            return result.FirstError;

        await _unitOfWork.BeginTransactionAsync();
        await _ticketMessageRepository.AddAsync(result.Value);

        var commitState = await _unitOfWork.CommitAsync();

        if (commitState.Value == Domain.Contract.Enums.TransactionStatus.Error)
            return new CreateTicketMessageCommandResult("error", "Add TicketMessage has error and rollback is done");

        return new CreateTicketMessageCommandResult("success", "ok");
    }
}
