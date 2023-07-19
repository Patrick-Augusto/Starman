using System.Data.Entity;

namespace Infrastructure.Persistence
{
    public class MyDbContext : DbContext
    {
        public DbSet<StockItem> StockItems { get; set; }

        public MyDbContext(string connectionString) : base(connectionString)
        {
        }
    }
}
