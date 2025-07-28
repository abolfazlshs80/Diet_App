using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.Users.Delete;
namespace Diet.Domain.UseCase.Users.Commands.Create
{
    public class DeleteUsersCommandValidator : AbstractValidator<DeleteUsersCommand>
    {
        public DeleteUsersCommandValidator()
        {
            // Add validation rules here
        }
    }
}
