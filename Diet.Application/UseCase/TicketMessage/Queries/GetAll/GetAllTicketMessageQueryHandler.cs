using Diet.Domain.ticketMessage.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.TicketMessage.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.TicketMessage.Queries.GetAll;

public class GetAllTicketMessageQueryHandler : IQueryHandler<GetAllTicketMessageQuery, GetAllTicketMessageQueryResult>
{
    private readonly ITicketMessageRepository _ticketMessageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketMessageQueryHandler(ITicketMessageRepository ticketMessageRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _ticketMessageRepository = ticketMessageRepository;
    }

    public async Task<ErrorOr<GetAllTicketMessageQueryResult>> Handle(GetAllTicketMessageQuery query)
    {
        var result = await _ticketMessageRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllTicketMessageQueryResult(
            result.Count,
            result.Select(_ => new GetTicketMessageItem(_.Id,_.TextMessage,_.FileName,_.TicketId,_.FromId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
