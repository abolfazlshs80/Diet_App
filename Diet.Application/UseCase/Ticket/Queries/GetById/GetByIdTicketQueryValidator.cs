using FluentValidation;
using Diet.Domain.Contract.Queries.Ticket.GetById;
namespace Diet.Application.UseCase.Ticket.Queries.GetById;

public class GetByIdTicketQueryValidator : AbstractValidator<GetByIdTicketQuery>
{
    public GetByIdTicketQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
