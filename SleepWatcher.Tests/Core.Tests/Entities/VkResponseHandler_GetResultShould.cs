using NUnit.Framework;
using System;
using System.Collections;
using SleepWatcher.Core.Entities.Common;

namespace SleepWatcher.UnitTests.Core.Entities
{
    [TestFixture]
    public class VkResponseHandler_GetResultShould
    {
        private VkResponseHandler _vkResponseHandler;

        [SetUp]
        public void SetUp()
        {
            _vkResponseHandler = new VkResponseHandler();
        }

        [Test]
        public void GetResult_JsonIsIncorrect_ThrowsJsonException()
        {
            Assert.Throws<System.Text.Json.JsonException>(() => _vkResponseHandler.GetResult("Hello"));
        }

        [Test]
        public void GetResult_InputIsIncorrect_ThrowsArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => _vkResponseHandler.GetResult("{}"));
        }
        
        [Test]
        public void GetResult_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => _vkResponseHandler.GetResult(null));
        }

        [Test]
        public void GetResult_InputWithError_ReturnsEmptyCollection()
        {
            var actual = _vkResponseHandler.GetResult("{\"response\": [{\"peer_id\": 529900012,\"error\": {\"code\": 901,\"description\": \"Can't send messages for users without permission\"}}]}");
            Assert.IsEmpty(actual);
        }

        [Test]
        public void GetResult_InputWithoutError_ReturnsCollectionOfId()
        {
            var expected = new int[] {46453314}; 
            var actual = _vkResponseHandler.GetResult("{\"response\": [{\"peer_id\": 46453314,\"message_id\": 23,\"conversation_message_id\": 11}]}");
            Assert.AreEqual(expected, actual);
        }
    }
}