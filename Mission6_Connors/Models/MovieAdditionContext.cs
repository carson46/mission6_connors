using Microsoft.EntityFrameworkCore;

namespace Mission6_Connors.Models
{
    public class MovieAdditionContext : DbContext
    {
        public MovieAdditionContext(DbContextOptions<MovieAdditionContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
}

