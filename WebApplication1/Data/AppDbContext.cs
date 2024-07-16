using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book).WithMany(b => b.Book_Authors).HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).WithMany(b => b.Book_Authors).HasForeignKey(bi => bi.AuthorId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
