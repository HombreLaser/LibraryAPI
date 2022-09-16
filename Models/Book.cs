namespace LibraryAPI.Models {
    public class Book {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public Author? Author { get; set; }
        public int PublicationYear { get; set; }
        public string[]? Genres { get; set; }
        public int Edition { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
    }
}