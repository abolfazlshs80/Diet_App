using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Users.Update;
namespace Diet.Domain.UseCase.Users.Commands.Create
{
    public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommand>
    {
        public UpdateUsersCommandValidator()
        {
            // Add validation rules here
        }
    }
}
