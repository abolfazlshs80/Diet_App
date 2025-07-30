

using FluentValidation;
using Identity.Domain.Contract.Commands.User.Login;

namespace Identity.Application.UseCase.User.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Mobile).NotEmpty().MaximumLength(11).WithMessage("Please Enter a mobile number  ");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please Enter a password ");
    }
}
