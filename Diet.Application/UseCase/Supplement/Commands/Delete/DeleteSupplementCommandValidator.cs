using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Supplement.Delete;
namespace Diet.Domain.UseCase.Supplement.Commands.Create
{
    public class DeleteSupplementCommandValidator : AbstractValidator<DeleteSupplementCommand>
    {
        public DeleteSupplementCommandValidator()
        {
            // Add validation rules here
        }
    }
}
