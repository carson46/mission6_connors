// Import necessary namespace for Entity Framework Core
using Microsoft.EntityFrameworkCore;

namespace Mission6_Connors.Models
{
    // This class represents the database context for the application
    // It manages the connection to the database and handles CRUD operations
    public class MovieAdditionContext : DbContext
    {
        // Constructor: Receives database options and passes them to the base DbContext class
        public MovieAdditionContext(DbContextOptions<MovieAdditionContext> options) : base(options)
        {
            // The base constructor ensures that the options (such as connection string) are set up properly
        }

        // DbSet property representing the "Movies" table in the database
        // This allows querying and updating movies stored in the database
        public DbSet<Movie> Movies { get; set; }
    }
}

