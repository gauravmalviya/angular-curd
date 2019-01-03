using bookapi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookapi.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>(entity => { entity.ToTable(name: "Author"); });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


    }
}