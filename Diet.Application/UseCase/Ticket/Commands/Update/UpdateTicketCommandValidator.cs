using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Ticket.Update;
namespace Diet.Domain.UseCase.Ticket.Commands.Create
{
    public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        public UpdateTicketCommandValidator()
        {
            // Add validation rules here
        }
    }
}
