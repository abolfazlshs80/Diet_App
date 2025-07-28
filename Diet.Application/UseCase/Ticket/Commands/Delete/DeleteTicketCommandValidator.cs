using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Ticket.Delete;
namespace Diet.Domain.UseCase.Ticket.Commands.Create
{
    public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
    {
        public DeleteTicketCommandValidator()
        {
            // Add validation rules here
        }
    }
}
