

using Diet.Domain.Contract.Commands.Account.Register;
using Diet.Domain.Contract.DTOs.Authentication;
using FluentValidation;

namespace Identity.Application.UseCase.User.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Firstname).NotEmpty().Length(2, 50).WithMessage("Please  Enter a first name"); 
        RuleFor(x => x.Lastname).NotEmpty().Length(2, 50).WithMessage("Please Enter a last name"); 
   
        RuleFor(x => x.MobileNumber).NotEmpty().MaximumLength(11).WithMessage("Please Enter a mobile number  ");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please Enter a password ");
   
       // RuleFor(x => x.ListUserRole).NotNull().SetValidator(new UserRoleValidator());

    }
}
