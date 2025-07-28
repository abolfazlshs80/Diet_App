using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementGroup.Create;
namespace Diet.Domain.UseCase.SupplementGroup.Commands.Create
{
    public class CreateSupplementGroupCommandValidator : AbstractValidator<CreateSupplementGroupCommand>
    {
        public CreateSupplementGroupCommandValidator()
        {
            // Add validation rules here
        }
    }
}
