namespace VideoStreamingUserServiceApplication.Applications.Common.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
