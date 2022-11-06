using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs {
    public class CreateUserAccount {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}