using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(uint id);
        Task<User[]> GetActiveUsersAsync();
    }
}
