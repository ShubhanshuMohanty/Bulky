using Microsoft.EntityFrameworkCore;
using Bulky.Models;
namespace Bulky.Data
{
    public class ApplicationDbContext:DbContext
    {
        //ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
