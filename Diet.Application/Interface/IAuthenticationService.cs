using Diet.Domain.Contract.Commands.Account.Register;
using Diet.Framework.Core.Interface;
using ErrorOr;
using Identity.Domain.Contract.Commands.User.Login;
using System.Threading.Tasks;

namespace Diet.Application.Interface;

public interface IAuthenticationService
{
    Task<ErrorOr<string>> Login(LoginUserCommand dto);
    Task<ErrorOr<Success>> Register(RegisterUserCommand dto);

}
