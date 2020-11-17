using Microsoft.EntityFrameworkCore;
using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Data.Context
{
    public class SleepWatcherContext : DbContext
    {

        public SleepWatcherContext(DbContextOptions<SleepWatcherContext> options)
          : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<SleepTimeSetting> SleepTimeSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(254); //https://stackoverflow.com/questions/386294/what-is-the-maximum-length-of-a-valid-email-address

            modelBuilder.Entity<User>()
            .HasKey(u => u.VkId);
          
            
            modelBuilder.Entity<User>()
            .Property(u => u.VkId)
            .ValueGeneratedNever();

             modelBuilder.Entity<SleepTimeSetting>()
            .HasIndex(s => new {s.BeginSleepTime, s.EndSleepTime})
            .IsUnique();

            
        }

    }
}