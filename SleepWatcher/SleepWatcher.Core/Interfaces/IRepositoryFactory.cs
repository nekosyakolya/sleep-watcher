using System;

namespace SleepWatcher.Core.Interfaces
{
    public interface IRepositoryFactory<TRepository>
    {
        void ExecuteAndCommit(Action<TRepository> action);
    }
}