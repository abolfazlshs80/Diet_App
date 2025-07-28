using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Supplement.Create;
namespace Diet.Domain.UseCase.Supplement.Commands.Create
{
    public class CreateSupplementCommandValidator : AbstractValidator<CreateSupplementCommand>
    {
        public CreateSupplementCommandValidator()
        {
            // Add validation rules here
        }
    }
}
