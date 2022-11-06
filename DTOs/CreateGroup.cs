using System.ComponentModel.DataAnnotations;
using LibraryAPI.Validators;

namespace LibraryAPI.DTOs {
    public class CreateGroup {
        [Required]
        [Name]
        public string? Name { get; set; }
    }
}