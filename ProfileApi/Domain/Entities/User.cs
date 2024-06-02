using ExampleCore.Dal.Base;

namespace Domain.Entities
{
    public record User(string Name, string Surname, bool Online, string Login, string Password) : BaseEntityDal<uint>;
}
