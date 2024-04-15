using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UserDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=UserRepository;User Id=postgres;password=8778");
        }
    }
}
//Example of data
//
//INSERT INTO public."Users"("Id", "Name", "Surname", "Online", "Login", "Password")
//VALUES
//(1, 'John', 'Doe', true, 'john_doe', 'password123'),
//(2, 'Alice', 'Smith', false, 'alice_smith', 'securepassword'),
//(3, 'Bob', 'Johnson', true, 'bob_johnson', '123456'),
//(4, 'Emily', 'Davis', false, 'emily_davis', 'p@ssw0rd'),
//(5, 'Michael', 'Brown', true, 'michael_brown', 'qwerty');

