using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models {
    public class LibraryContext : DbContext {
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}
    }
}