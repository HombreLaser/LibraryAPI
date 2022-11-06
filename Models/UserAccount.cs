using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Models {
    public class UserAccount {
	public long Id { get; set; }
	[Required]
	public string? Email { get; set; }
        private string? _password;
        [Required]
	public string? Password { get { return _password; } set { _password = HashPassword(value); } }
	public ICollection<GroupUserAccount>? Groups { get; set; }
        private PasswordHasher<UserAccount> _hasher;

	public UserAccount() {
	    _hasher = new PasswordHasher<UserAccount>();
	}

	public PasswordVerificationResult VerifyPassword(string to_verify) {
	     return _hasher.VerifyHashedPassword(this, Password, to_verify);
	}
	
	private string? HashPassword(string? unhashed_password) {
	    if(unhashed_password != null)
		return _hasher.HashPassword(this, unhashed_password);

	    return null;
	}
    }
}
