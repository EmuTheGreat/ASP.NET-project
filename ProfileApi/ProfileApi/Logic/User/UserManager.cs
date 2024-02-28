using ProfileApi.Dal.User;

namespace ProfileApi.Logic.User;

internal class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> GetUserNameAsync(Guid userId)
    {
        return await _userRepository.GetUserNameAsync(userId);
    }

    public async Task<Guid> CreateUserAsync(UserLogic user)
    {
        return await _userRepository.CreateUserAsync(new UserDal
        {
            Name = user.Name,
            Login = user.Login,
            Phone = user.Phone,
            Email = user.Email,
            Country = user.Country,
        });
    }
}

