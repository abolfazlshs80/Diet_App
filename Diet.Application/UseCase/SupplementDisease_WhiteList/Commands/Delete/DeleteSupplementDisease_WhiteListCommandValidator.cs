using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Delete;
namespace Diet.Domain.UseCase.SupplementDisease_WhiteList.Commands.Create
{
    public class DeleteSupplementDisease_WhiteListCommandValidator : AbstractValidator<DeleteSupplementDisease_WhiteListCommand>
    {
        public DeleteSupplementDisease_WhiteListCommandValidator()
        {
            // Add validation rules here
        }
    }
}
