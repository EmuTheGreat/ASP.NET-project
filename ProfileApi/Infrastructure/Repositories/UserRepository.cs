using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private UserDbContext _db;
        public UserRepository(UserDbContext dbContext) 
        {
            _db = dbContext;
        }
        public async Task<User> GetUserAsync(uint id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User[]> GetUsersByAsync(Expression<Func<User, bool>> predicate)
        {
            return await _db.Users.Where(predicate).ToArrayAsync();
        }
    }
}
