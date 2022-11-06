using System.ComponentModel.DataAnnotations;
using LibraryAPI.Models;

namespace LibraryAPI.Validators {
    public class NameAttribute : ValidationAttribute {
        public string[] valid_names = { "regular", "librarian" };
	public string GetErrorMessage() {
            return "Group name must be \"regular\" or \"librarian\"";
        }

	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
	    var group = (Group) validationContext.ObjectInstance;

	    if(Array.Exists(valid_names, s => s == group.Name))
		return ValidationResult.Success;

	    return new ValidationResult(GetErrorMessage());
	}
    }
}
