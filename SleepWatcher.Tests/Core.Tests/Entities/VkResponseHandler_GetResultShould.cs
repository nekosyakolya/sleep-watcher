using NUnit.Framework;
using System;
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
    }
}