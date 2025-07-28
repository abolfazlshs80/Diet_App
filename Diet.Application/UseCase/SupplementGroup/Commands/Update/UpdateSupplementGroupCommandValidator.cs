using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementGroup.Update;
namespace Diet.Domain.UseCase.SupplementGroup.Commands.Create
{
    public class UpdateSupplementGroupCommandValidator : AbstractValidator<UpdateSupplementGroupCommand>
    {
        public UpdateSupplementGroupCommandValidator()
        {
            // Add validation rules here
        }
    }
}
