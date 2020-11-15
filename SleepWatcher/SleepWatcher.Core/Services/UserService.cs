using SleepWatcher.Core.Entities.DTO;
using SleepWatcher.Core.Interfaces;

namespace SleepWatcher.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        
        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public User GetUser(string id)
        {
            return repository.FindById(id);
        }

        public void AddUser(User user)
        {
            repository.Add(user);
        }
    }
}