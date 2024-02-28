namespace ProfileApi.Logic.User
{
    public interface IUserManager
    {
        Task<string> GetUserNameAsync(Guid userId);
        Task<Guid> CreateUserAsync(UserLogic user);
    }
}
