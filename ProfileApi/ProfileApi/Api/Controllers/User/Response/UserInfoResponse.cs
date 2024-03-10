namespace ProfileApi.Api.Controllers.User.Response
{
    public class UserInfoResponse
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required string Email { get; init; }

        public required string Country { get; init; }

        public required string Phone { get; init; }

        public required string Login { get; init; }
    }
}
