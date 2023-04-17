using ErrorOr;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(UserId id);

        Task<User>? GetUserByEmail(string email);
        Task<User>? GetUserByUsername(string username);
        Task<ErrorOr<bool>> AddAdminByUsername(string username);
        Task UpdateUser(string username);
        public UserId GetUserId();
        void Add(User user);
    }
}
