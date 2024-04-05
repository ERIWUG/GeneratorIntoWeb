
using Microsoft.EntityFrameworkCore;

namespace GeneratorIntoWeb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MyData> Questions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}