namespace MercuryProject.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string Role,
        string Username,
        string FirstName,
        string LastName,
        string Email,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime,
        string Token);
}
