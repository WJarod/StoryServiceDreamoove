using StoryServiceDreamoove.Models;
using Microsoft.EntityFrameworkCore;

namespace StoryServiceDreamoove.Data
{
    public class AppDbContext : DbContext
    {
        // Pont entre notre bdd et notre model 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        //On set le model avec le nom de la bdd
        public DbSet<Story> Story { get; set; }

        public DbSet<User> User { get; set; }
    }
}