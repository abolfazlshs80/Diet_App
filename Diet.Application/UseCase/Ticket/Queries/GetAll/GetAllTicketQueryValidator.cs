using FluentValidation;
using Diet.Domain.Contract.Queries.Ticket.GetAll;
namespace Diet.Application.UseCase.Ticket.Queries.GetAll;

public class GetAllTicketQueryValidator : AbstractValidator<GetAllTicketQuery>
{
    public GetAllTicketQueryValidator()
    {
        
    }
}
