using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Sport.Delete;
namespace Diet.Domain.UseCase.Sport.Commands.Create
{
    public class DeleteSportCommandValidator : AbstractValidator<DeleteSportCommand>
    {
        public DeleteSportCommandValidator()
        {
            // Add validation rules here
        }
    }
}
