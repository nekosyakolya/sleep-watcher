using System.Collections;

namespace SleepWatcher.Core.Entities.Common
{
    public interface IResponseHandler
    {
        IEnumerable GetResult(string response);        
    }
}