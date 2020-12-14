using System.Threading.Tasks;

namespace SleepWatcher.Core.Entities.Common
{
    public interface ISender
    {
      Task<string> Send(string to, string message);  
    }
}