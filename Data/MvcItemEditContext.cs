using Microsoft.EntityFrameworkCore;

namespace MvcEcommerce.Data
{
    public class MvcItemEditContext : DbContext
    {
        public MvcItemEditContext(DbContextOptions<MvcItemEditContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEcommerce.Models.Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=MvcItemEditContext.db");
            }
        }
    }
}
