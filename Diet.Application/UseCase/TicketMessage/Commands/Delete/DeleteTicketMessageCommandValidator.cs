using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.TicketMessage.Delete;
namespace Diet.Domain.UseCase.TicketMessage.Commands.Create
{
    public class DeleteTicketMessageCommandValidator : AbstractValidator<DeleteTicketMessageCommand>
    {
        public DeleteTicketMessageCommandValidator()
        {
            // Add validation rules here
        }
    }
}
