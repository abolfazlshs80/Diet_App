using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;
namespace Diet.Domain.UseCase.SupplementDisease_WhiteList.Commands.Create
{
    public class UpdateSupplementDisease_WhiteListCommandValidator : AbstractValidator<UpdateSupplementDisease_WhiteListCommand>
    {
        public UpdateSupplementDisease_WhiteListCommandValidator()
        {
            // Add validation rules here
        }
    }
}
