using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.TicketMessage.Update;
namespace Diet.Domain.UseCase.TicketMessage.Commands.Create
{
    public class UpdateTicketMessageCommandValidator : AbstractValidator<UpdateTicketMessageCommand>
    {
        public UpdateTicketMessageCommandValidator()
        {
            // Add validation rules here
        }
    }
}
