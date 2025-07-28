using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementGroup.Delete;
namespace Diet.Domain.UseCase.SupplementGroup.Commands.Create
{
    public class DeleteSupplementGroupCommandValidator : AbstractValidator<DeleteSupplementGroupCommand>
    {
        public DeleteSupplementGroupCommandValidator()
        {
            // Add validation rules here
        }
    }
}
