using System.Collections.Generic;
using SleepWatcher.Core.Entities.DTO;
using SleepWatcher.Core.Interfaces;
using SleepWatcher.Data.Context;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace SleepWatcher.Data.Repositories
{
    public class EFRepository : IUserRepository,
    IUsersToSleepRepository
    {
        private readonly SleepWatcherContext _context;
        public EFRepository(SleepWatcherContext context)
        {
            _context = context;
        }

        IReadOnlyCollection<User> IUsersToSleepRepository.Get()
        {
            var time = DateTime.Now.TimeOfDay;
            var query = from settings in _context.SleepTimeSettings
                        where (settings.BeginSleepTime.TimeOfDay <= settings.EndSleepTime.TimeOfDay) ?
                        settings.BeginSleepTime.TimeOfDay <= time &&
                                          settings.EndSleepTime.TimeOfDay > time
                                          : settings.BeginSleepTime.TimeOfDay <= time ||
                                          settings.EndSleepTime.TimeOfDay >= time
                        join users in _context.Users
                               on settings.Id equals users.SleepTimeSetting.Id
                        select new User()
                        {
                            VkId = users.VkId,
                            Email = users.Email,
                            SleepTimeSetting = new SleepTimeSetting
                            {
                                BeginSleepTime = settings.BeginSleepTime,
                                EndSleepTime = settings.EndSleepTime,
                                Id = settings.Id
                            }
                        };
            return query.ToList();
        }

        void IUserRepository.Add(User user)
        {
            var query = from settings in _context.SleepTimeSettings
                        where settings.BeginSleepTime.Equals(user.SleepTimeSetting.BeginSleepTime) &&
                              settings.EndSleepTime.Equals(user.SleepTimeSetting.EndSleepTime)
                        select settings;

            var sleepTimeSettings = query.FirstOrDefault();
            if (sleepTimeSettings != null)
            {
                user.SleepTimeSetting = sleepTimeSettings;
            }

            _context.Users.Add(user);
        }

        User IUserRepository.FindById(int id)
        {
            return _context.Users.FirstOrDefault(e => e.VkId == id);
        }
    }
}