using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Core.Interfaces
{
    public interface IUserRepository
    {
        public void Add(User user);
        public User FindById(int id);
    }
}