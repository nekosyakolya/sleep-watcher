namespace SleepWatcher.Core.Entities.DTO
{
    public class User
    {
        public string VkId { get; set; }
        public string Email { get; set; }
        public SleepTimeSetting SleepTimeSetting { get; set; }
    }
}