using Dal.Post.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Post.Contexts
{
    public class PostContext : DbContext
    {
        public DbSet<PostCounterDal> Counter { get; set; } = null!;
        public DbSet<PostDal> Posts { get; set; } = null!;

        public PostContext()
        {
            //Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=PostRepository;User Id=postgres;password=8778");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostDal>()
                .HasKey(x => new { x.Id, x.AuthorId });
        }
    }
}
