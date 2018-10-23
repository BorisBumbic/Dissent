using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DissentTest
{
    [TestClass]
    public class SentimentApiServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = Dissent.SentimentApiService.RequestSentiment()
        }
    }
}
