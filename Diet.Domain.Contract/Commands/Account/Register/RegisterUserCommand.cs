using Diet.Domain.Contract.DTOs.Authentication;
using Diet.Framework.Core.Bus;
using System.Collections.Generic;

namespace Diet.Domain.Contract.Commands.Account.Register;

public record RegisterUserCommand(
    string Firstname,
    string Lastname,
    string Password,
    string Salt,
    string MobileNumber
    ) : ICommand;
 
