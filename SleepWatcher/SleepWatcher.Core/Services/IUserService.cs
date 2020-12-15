using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Core.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        void AddUser(User user);
    }
}