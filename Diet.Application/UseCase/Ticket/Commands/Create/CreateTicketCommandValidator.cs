using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Ticket.Create;
namespace Diet.Domain.UseCase.Ticket.Commands.Create
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            // Add validation rules here
        }
    }
}
