using Microsoft.EntityFrameworkCore;
using Bulky.Models;
namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        //data insert kar raha hu or onModelCreating method ko override kar raha hu 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Romance", DisplayOrder = 3 }
            );
        }
    }
}
