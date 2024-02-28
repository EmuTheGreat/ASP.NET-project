using ProfileApi.Core.Dal_Base;

namespace ProfileApi.Dal.User
{
    public record UserDal : BaseEntityDal
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }

        public required string Login { get; init; }

        public required string Phone { get; init; }

        public required string Email { get; init; }

        public required string Country { get; init; }
    }
}
