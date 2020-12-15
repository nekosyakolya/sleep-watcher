namespace SleepWatcher.Core.Entities.DTO
{
    public class User
    {
        public int VkId { get; set; }
        public string Email { get; set; }
        public SleepTimeSetting SleepTimeSetting { get; set; }
    }
}