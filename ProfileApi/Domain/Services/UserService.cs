using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<User[]> GetActiveUsersAsync()
        {
            return await _userRepository.GetUsersByAsync(user => user.Online);
        }

        public async Task<User> GetUserAsync(uint id)
        {
            return await _userRepository.GetUserAsync(id);
        }
    }
}
