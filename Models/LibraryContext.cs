using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models {
    public class LibraryContext : DbContext {
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
	public DbSet<UserAccount>? Users { get; set; }
	public DbSet<Group>? Groups { get; set; }
	public DbSet<GroupUserAccount>? GroupUserAccounts { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<GroupUserAccount>().HasKey(sc => new { sc.UserAccountId, sc.GroupId });
        }
    }
}
