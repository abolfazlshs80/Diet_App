using Diet.Application.Interface;
using Diet.Domain.ticketMessage.Repository;
using Diet.Domain.Contract.Commands.TicketMessage.Create;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.TicketMessage.Commands.Create;

public class CreateTicketMessageCommandHandler : ICommandHandler<CreateTicketMessageCommand, CreateTicketMessageCommandResult>
{
    private readonly ITicketMessageRepository _ticketMessageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketMessageCommandHandler(ITicketMessageRepository ticketMessageRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketMessageRepository = ticketMessageRepository;
    }

    public async Task<ErrorOr<CreateTicketMessageCommandResult>> Handle(CreateTicketMessageCommand command)
    {
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
