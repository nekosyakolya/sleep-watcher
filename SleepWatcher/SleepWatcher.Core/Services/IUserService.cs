using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Core.Services
{
    public interface IUserService
    {
        User GetUser(string id);
        void AddUser(User user);
    }
}