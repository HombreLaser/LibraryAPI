namespace LibraryAPI.DTOs {
    public class UserAccountDTO {
        public long Id { get; set; }
        public string? Email { get; set; }
        public List<GroupDTO>? Groups { get; set; }
    }
}