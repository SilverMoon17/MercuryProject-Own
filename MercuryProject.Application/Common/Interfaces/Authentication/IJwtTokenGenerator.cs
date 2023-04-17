using MercuryProject.Domain.User;

namespace MercuryProject.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
