using FluentValidation;
using Diet.Domain.Contract.Queries.TicketMessage.GetById;
namespace Diet.Application.UseCase.TicketMessage.Queries.GetById;

public class GetByIdTicketMessageQueryValidator : AbstractValidator<GetByIdTicketMessageQuery>
{
    public GetByIdTicketMessageQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
