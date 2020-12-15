using SleepWatcher.Core.Entities.DTO;
using SleepWatcher.Core.Interfaces;

namespace SleepWatcher.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryFactory<IUserRepository> _repositoryFactory;

        public UserService(IRepositoryFactory<IUserRepository> repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public User GetUser(int id)
        {
            User user = null;
             _repositoryFactory.ExecuteAndCommit(repository =>
                {
                    user = repository.FindById(id);
                });
            return user;
        }

        public void AddUser(User user)
        {
            _repositoryFactory.ExecuteAndCommit(repository =>
                {
                    repository.Add(user);
                });

        }
    }
}