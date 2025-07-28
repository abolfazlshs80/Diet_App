using Diet.Domain.ticket.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Ticket.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.Ticket.Queries.GetAll;

public class GetAllTicketQueryHandler : IQueryHandler<GetAllTicketQuery, GetAllTicketQueryResult>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketQueryHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketRepository = ticketRepository;
    }

    public async Task<ErrorOr<GetAllTicketQueryResult>> Handle(GetAllTicketQuery query)
    {
        var result = await _ticketRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllTicketQueryResult(
            result.Count,
            result.Select(_ => new GetTicketItem(_.Id,_.Title,_.Number,(int)(_.Priority), (int)_.Status,_.UserId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
