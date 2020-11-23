using System;
using SleepWatcher.Data.Context;

namespace SleepWatcher.Data.Repositories
{
    public abstract class RepositoryFactoryBase<TRepository>
    {
        private readonly Func<SleepWatcherContext> _dbContextFactory;

        protected RepositoryFactoryBase(Func<SleepWatcherContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void ExecuteAndCommit(Action<TRepository> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            var db = _dbContextFactory();
            using (var transaction = db.Database.BeginTransaction())
            {
                var repository = CreateRepository(db);
                action(repository);
                db.SaveChanges();

                transaction.Commit();
            }
        }

        protected abstract TRepository CreateRepository(SleepWatcherContext db);
    }
}