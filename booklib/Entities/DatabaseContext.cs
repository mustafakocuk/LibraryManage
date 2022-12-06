using Microsoft.EntityFrameworkCore;

namespace booklib.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }        
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lib> Libs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Lib>().HasKey(table => new
            {
                table.BookId,
                table.UserId
            });
        }
    }
}
