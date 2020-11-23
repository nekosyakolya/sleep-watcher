using System.Collections.Generic;
using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Core.Entities.Common
{
    public interface IUsersToSleepService
    {
        public IEnumerable<User> Get();
    }
}