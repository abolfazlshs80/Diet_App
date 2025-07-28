using Diet.Domain.ticket.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Ticket.GetById;

namespace Diet.Application.UseCase.Ticket.Queries.GetById;

public class GetByIdTicketQueryHandler : IQueryHandler<GetByIdTicketQuery, GetByIdTicketQueryResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdTicketQueryHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<GetByIdTicketQueryResult>> Handle(GetByIdTicketQuery query)
    {
        var result = await _ticketRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Ticket not found");

        return new GetByIdTicketQueryResult(result.Id,result.Title,result.Number, (int)result.Priority, (int)result.Status,result.UserId);
    }
}
