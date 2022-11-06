using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models {
    public class GroupUserAccount {
    [Required]
    public long GroupId { get; set; }
	public Group Group { get; set; }
    [Required]
	public long UserAccountId { get; set; }
	public UserAccount UserAccount { get; set; }
    }
}
