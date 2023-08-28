using Microsoft.EntityFrameworkCore;
using RazorWeb.Model;

namespace RazorWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }
        public DbSet<Category> Categories { get; set; }
    }
}
