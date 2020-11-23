using System.Collections.Generic;
using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Core.Interfaces
{
    public interface IUsersToSleepRepository
    {
        public IReadOnlyCollection<User> Get();
    }
}