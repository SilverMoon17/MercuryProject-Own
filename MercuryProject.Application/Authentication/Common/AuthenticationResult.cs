using MercuryProject.Domain.User;

namespace MercuryProject.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
