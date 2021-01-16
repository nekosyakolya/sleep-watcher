using System;
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
        private class Container
        {
            public List<Item> response { get; set; }
        }

        public IEnumerable GetResult(string response)
        {
            var container = JsonSerializer.Deserialize<Container>(response);
            var items = container?.response;
            if (items == null)
            {
                throw new ArgumentException("Incorrect json");
            }

            return GetResult(items);
        }

        private IEnumerable GetResult(List<Item> items)
        {
            foreach (var item in items)
            {
                if (item.error == null)
                {
                    yield return item.peer_id;
                }
            }
        }
    }
}