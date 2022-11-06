namespace LibraryAPI.DTOs {
    public class AuthenticationToken {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
