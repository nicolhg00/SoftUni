namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(m => new { m.AuthorId, m.BookId });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}