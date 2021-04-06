using Microsoft.EntityFrameworkCore;

namespace ExcelParser
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Users.db");
    }
}