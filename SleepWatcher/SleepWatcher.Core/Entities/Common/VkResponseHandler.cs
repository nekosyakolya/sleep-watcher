using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace SleepWatcher.Core.Entities.Common
{
    public class VkResponseHandler : IResponseHandler
    {
        private class Item
        {
            public int peer_id { get; set; }
            public object error { get; set; }
        }
        private class Response
        {
            public List<Item> response { get; set; }
        }
        public IEnumerable GetResult(string response)
        {
            var result = JsonSerializer.Deserialize<Response>(response);
            foreach (var item in result.response)
            {
                if (item.error == null)
                {
                    yield return item.peer_id;
                }
            }
        }
    }
}