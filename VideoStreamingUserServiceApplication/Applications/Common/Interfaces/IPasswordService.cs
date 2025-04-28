namespace VideoStreamingUserServiceApplication.Applications.Common.Interfaces
{
    public interface IPasswordService
    {
       string HashPassword(string password);
    }
}
