using System.Collections.Generic;
using SleepWatcher.Core.Entities.DTO;
using SleepWatcher.Core.Interfaces;

namespace SleepWatcher.Core.Entities.Common
{
    public class UsersToSleepService : IUsersToSleepService
    {
        private readonly IRepositoryFactory<IUsersToSleepRepository> _repositoryFactory;
        public UsersToSleepService(IRepositoryFactory<IUsersToSleepRepository> repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public IEnumerable<User> Get()
        {
            IEnumerable<User> users = null;
            _repositoryFactory.ExecuteAndCommit(repository =>
                {
                    users = repository.Get();
                });
            return users;
        }
    }
}