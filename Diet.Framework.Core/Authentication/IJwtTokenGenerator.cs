namespace Diet.Framework.Core.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, List<string> roles);
}
