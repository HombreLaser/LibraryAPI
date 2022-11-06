using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models {
    public class GroupUserAccount {
        public long GroupId { get; set; }
	public Group? Group { get; set; }
	public long UserAccountId { get; set; }
	public UserAccount? UserAccount { get; set; }
    }
}
