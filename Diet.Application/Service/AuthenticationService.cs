using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Account.Register;
using Diet.Domain.Contract.DTOs.Authentication;
using Diet.Domain.Contract.Enums;
using Diet.Domain.role.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Authentication;
using ErrorOr;
using Identity.Domain.Contract.Commands.User.Login;

namespace Diet.Application.Service;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUsersRepository _IuserRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _IroleRepository;
    private readonly IEncrypter _Iencrypter;
    private readonly IJwtTokenGenerator _IjwtTokenGenerator;

    public AuthenticationService(
        IUsersRepository IuserRepository,
        IEncrypter Iencrypter,

        IUnitOfWork unitOfWork,
        IRoleRepository IroleRepository,
        IJwtTokenGenerator ijwtTokenGenerator)
    {
        _IuserRepository = IuserRepository;
        _Iencrypter = Iencrypter;
        _IroleRepository = IroleRepository;
        _IjwtTokenGenerator = ijwtTokenGenerator;
        _unitOfWork=unitOfWork;
    }

    public async Task<ErrorOr<string>> Login(LoginUserCommand dtoLogin)
    {
        var _user = await _IuserRepository.GetUser( dtoLogin.Mobile);
        if (_user is null)
            return Errors.ApplicationErrors.Authentication.UserLoginIsEmpty;

        var _password = _Iencrypter.GetHash(dtoLogin.Password, _user.Salt);
        if (_password != _user.Password)
            return Errors.ApplicationErrors.Authentication.PasswordLoginNotMatch;

        if (_password == _user.Password)
        {
            var _roles = await _IuserRepository.GetRolesByUserId(_user.Id);
            return _IjwtTokenGenerator.GenerateToken(_user.Id, _roles);
        }

        return Errors.ApplicationErrors.Authentication.TokenLoginEmpty;
    }

    public async Task<ErrorOr<Success>> Register(RegisterUserCommand dtoUser)
    {
        var _salt = _Iencrypter.GetSalt();
        var _password = _Iencrypter.GetHash(dtoUser.Password, _salt);
        //var _role = await _IroleRepository.GetByName(EnumeRole.User);

        //if (_role is null)
        //    return Errors.ApplicationErrors.Authentication.RegisterNotFoundRole;

        var modifyDtoUser = dtoUser with
        {
            Salt = _salt,
            Password = _password,
       };

        var user =Domain.user. User.Create(modifyDtoUser);
        if (user.IsError)
            return user.FirstError;

        await _IuserRepository.AddAsync(user.Value);
        await _unitOfWork.SaveAsync();
        return Result.Success;
    }
}
