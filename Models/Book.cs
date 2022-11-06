using System.ComponentModel.DataAnnotations;
using LibraryAPI.Validators;

namespace LibraryAPI.Models {
    public class Book {
        public long Id { get; set; }
        [Required]
        public long AuthorId { get; set; }
        public Author? Author { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public string[]? Genres { get; set; }
        public int Edition { get; set; }
        [Required]
        [ISBN(13)]
        public string? ISBN { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Title too long")]
        public string? Title { get; set; }
    }
}
