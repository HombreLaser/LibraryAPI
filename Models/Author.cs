namespace LibraryAPI.Models {
    public class Author {
        public long Id { get; set; }
        public List<Book>? Books { get; set; }
        public string? Country { get; set; }
        public string? Name { get; set; }
        public int YearOfBirth { get; set; }
        public string[]? languages { get; set; }
    }
}