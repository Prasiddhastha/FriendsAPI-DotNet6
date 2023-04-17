using Microsoft.EntityFrameworkCore;

namespace Friends.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {}
        public DbSet<Friends>Friend { get; set; }

       
    }
}
