using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(uint id);
        Task<User[]> GetUsersByAsync(Expression<Func<User, bool>> predicate);

    }
}
