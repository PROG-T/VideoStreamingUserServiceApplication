using VideoStreamingUserServiceApplication.Domain.Enums;

namespace VideoStreamingUserServiceApplication.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } // admin, user
        public Subscription Subscription { get; set; }
        public UserProfile UserProfile {  get; set; }
    }
}
