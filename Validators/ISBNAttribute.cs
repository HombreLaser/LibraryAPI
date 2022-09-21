using System.ComponentModel.DataAnnotations;
using LibraryAPI.Models;

namespace LibraryAPI.Validators {
    public class ISBNAttribute : ValidationAttribute {
        public int ISBNlength { get; }

        public ISBNAttribute(int isbn_length) {
            ISBNlength = isbn_length;
        }

        public string GetErrorMessage() {
          return $"ISBN strings must be {ISBNlength} characters long";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            var book = (Book) validationContext.ObjectInstance;

            if(book.ISBN.Length != ISBNlength) {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}