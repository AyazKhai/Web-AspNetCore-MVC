using Microsoft.EntityFrameworkCore;

namespace WebApplicationTest.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Emploee> Emploees { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
