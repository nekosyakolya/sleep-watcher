using System;

namespace SleepWatcher.Core.Entities.DTO
{
    public class SleepTimeSetting
    {
        public int Id { get; set; }
        public DateTime BeginSleepTime { get; set; }
        public DateTime EndSleepTime { get; set; }
    }
}