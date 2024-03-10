namespace ProfileApi.Dal.User
{
    public interface IUserRepository
    {
        Task<string> GetUserNameAsync(Guid userId);
        Task<Guid> CreateUserAsync(UserDal user);
    }
}
