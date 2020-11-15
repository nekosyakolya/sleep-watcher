using System.Collections.Generic;
using System.Linq;
using SleepWatcher.Core.Entities.DTO;
using SleepWatcher.Data.Context;
using SleepWatcher.Core.Interfaces;

namespace SleepWatcher.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly SleepWatcherContext context; 
        public IEnumerable<User> All => context.Users.ToList();
        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        void IRepository<User>.Delete(User entity)
        {

        }

        void IRepository<User>.Update(User entity)
        {

        }

        public User FindById(string id)
        {
            return context.Users.FirstOrDefault(e => e.VkId == id);
        }

        User IRepository<User>.FindById(int id)
        {
            return new User();
        }

        public UserRepository(SleepWatcherContext context)
        {
            this.context = context;
        }
    }
}