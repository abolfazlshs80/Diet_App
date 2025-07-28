using Diet.Domain.ticketMessage.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.TicketMessage.GetById;

namespace Diet.Application.UseCase.TicketMessage.Queries.GetById;

public class GetByIdTicketMessageQueryHandler : IQueryHandler<GetByIdTicketMessageQuery, GetByIdTicketMessageQueryResult>
{
    private readonly ITicketMessageRepository _ticketMessageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdTicketMessageQueryHandler(ITicketMessageRepository ticketMessageRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketMessageRepository = ticketMessageRepository;
    }

    public async Task<ErrorOr<GetByIdTicketMessageQueryResult>> Handle(GetByIdTicketMessageQuery query)
    {
        var result = await _ticketMessageRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "TicketMessage not found");

        return new GetByIdTicketMessageQueryResult(result.Id,result.TextMessage,result.FileName,result.TicketId,result.FromId);
    }
}
