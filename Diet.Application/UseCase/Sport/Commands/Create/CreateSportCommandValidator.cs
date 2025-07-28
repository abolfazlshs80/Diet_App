using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Sport.Create;
namespace Diet.Domain.UseCase.Sport.Commands.Create
{
    public class CreateSportCommandValidator : AbstractValidator<CreateSportCommand>
    {
        public CreateSportCommandValidator()
        {
            // Add validation rules here
        }
    }
}
