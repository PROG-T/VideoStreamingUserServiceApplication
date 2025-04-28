using System.Security.Cryptography;
using System.Text;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;

namespace VideoStreamingUserServiceApplication.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes =  sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
