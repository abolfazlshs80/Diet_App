using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Supplement.Update;
namespace Diet.Domain.UseCase.Supplement.Commands.Create
{
    public class UpdateSupplementCommandValidator : AbstractValidator<UpdateSupplementCommand>
    {
        public UpdateSupplementCommandValidator()
        {
            // Add validation rules here
        }
    }
}
