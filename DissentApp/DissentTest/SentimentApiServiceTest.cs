using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dissent.SentimentApiServic;

namespace DissentTest
{
    [TestClass]
    public class SentimentApiServiceTest
    {
        [TestMethod]
        public void RequestSentiment_returns_value()
        {
            var result = SentimentApiService();
        }
    }
}
