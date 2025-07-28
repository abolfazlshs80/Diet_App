using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Sport.Update;
namespace Diet.Domain.UseCase.Sport.Commands.Create
{
    public class UpdateSportCommandValidator : AbstractValidator<UpdateSportCommand>
    {
        public UpdateSportCommandValidator()
        {
            // Add validation rules here
        }
    }
}
