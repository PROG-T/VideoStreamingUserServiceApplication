namespace VideoStreamingUserServiceApplication.Domain.Entities
{
    public class UserProfile
    {
        public long Id { get; set; }
        public long UserId {  get; set; }
        public User User {  get; set; }
        public string DisplayName { get; set; } 
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set; }

    }
}
