using FluentValidation;
using Diet.Domain.Contract.Queries.TicketMessage.GetAll;
namespace Diet.Application.UseCase.TicketMessage.Queries.GetAll;

public class GetAllTicketMessageQueryValidator : AbstractValidator<GetAllTicketMessageQuery>
{
    public GetAllTicketMessageQueryValidator()
    {
        
    }
}
