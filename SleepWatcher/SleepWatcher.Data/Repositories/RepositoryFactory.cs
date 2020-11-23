using System;
using SleepWatcher.Core.Interfaces;
using SleepWatcher.Data.Context;

namespace SleepWatcher.Data.Repositories
{
    public class RepositoryFactory : RepositoryFactoryBase<EFRepository>,
    IRepositoryFactory<IUserRepository>,
    IRepositoryFactory<IUsersToSleepRepository>
    {
        public RepositoryFactory(Func<SleepWatcherContext> dbContextFactory)
            : base(dbContextFactory)
        { }

        protected override EFRepository CreateRepository(SleepWatcherContext db)
        {
            return new EFRepository(db);
        }

        void IRepositoryFactory<IUserRepository>.ExecuteAndCommit(Action<IUserRepository> action)
        {
            ExecuteAndCommit(action);
        }


        void IRepositoryFactory<IUsersToSleepRepository>.ExecuteAndCommit(Action<IUsersToSleepRepository> action)
        {
            ExecuteAndCommit(action);
        }
    }
}