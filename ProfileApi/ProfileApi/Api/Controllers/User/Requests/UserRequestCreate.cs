namespace ProfileApi.Api.Controllers.User.Requests
{
    public record UserRequestCreate
    {
        public required string Name {  get; init; }

        public required string Login { get; init; }

        public required string Password { get; init; }

        public required string Email { get; init; }

        public required string Phone { get; init; }
        
        public required string Country { get; init; }

    }
}
