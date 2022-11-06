using System.ComponentModel.DataAnnotations;
using LibraryAPI.Validators;

namespace LibraryAPI.Models {
    public class Group {
	public long Id { get; set; }
	public ICollection<GroupUserAccount>? Users { get; set; }
	[Required]
	[Name]
	public string? Name { get; set; }
    }
}
