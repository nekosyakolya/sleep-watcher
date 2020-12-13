using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SleepWatcher.Core.Entities.Common
{
    public class VkSender : ISender
    {
        private readonly string _token;
        private static readonly string _versionApi = "5.126";
        private static readonly string _baseAddress = "https://api.vk.com";
        private static readonly string _sendingMethod = "/method/messages.send";

        public VkSender(string token)
        {
            _token = token;
        }

        public async Task<string> SendMessage(string message, string userID)
        {
            var rand = new Random();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("peer_ids", userID),
                    new KeyValuePair<string, string>("message", message),

                    new KeyValuePair<string, string>("random_id", rand.Next().ToString()),
                    new KeyValuePair<string, string>("access_token", _token),
                    new KeyValuePair<string, string>("v", _versionApi),
                 });
                HttpResponseMessage result = await client.PostAsync(_sendingMethod, content);
                var resultContent = await result.Content.ReadAsStringAsync();

                return resultContent;
            }
        }

        public async Task Send(string to, string message)
        {
            var result = await SendMessage(message, to);
        }
    }
}