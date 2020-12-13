using System.Threading.Tasks;

namespace SleepWatcher.Core.Entities.Common
{
    public interface ISender
    {
      Task Send(string to, string message);  
    }
}