using ManagingSalesOrderData.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagingSalesOrderData.DAL.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SubElement> SubElements { get; set; }

        public DbSet<Window> Windows { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
