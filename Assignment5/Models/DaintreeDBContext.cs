using Microsoft.EntityFrameworkCore;

namespace Assignment5.Models
{
    public class DaintreeDBContext : DbContext
    {
       public DaintreeDBContext (DbContextOptions<DaintreeDBContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<BookClassification> BookClassifications { get; set; }
    }
}
