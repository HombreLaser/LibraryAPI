using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models {
    public class Author {
        public long Id { get; set; }
        public List<Book>? Books { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Name too long")]
        public string? Name { get; set; }
        [Required]
        [Range(0, 2020, ErrorMessage = "Year out of valid range")]
        public int YearOfBirth { get; set; }
        [Required]
        public string[]? languages { get; set; }
    }
}