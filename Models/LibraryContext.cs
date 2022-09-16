using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models {
    public class LibraryContext : DbContext {
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=library;Username=luis");
    }
}