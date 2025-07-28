using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.TicketMessage.Create;
namespace Diet.Domain.UseCase.TicketMessage.Commands.Create
{
    public class CreateTicketMessageCommandValidator : AbstractValidator<CreateTicketMessageCommand>
    {
        public CreateTicketMessageCommandValidator()
        {
            // Add validation rules here
        }
    }
}
