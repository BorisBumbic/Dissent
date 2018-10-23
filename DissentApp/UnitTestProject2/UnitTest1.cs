using Dissent.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<RawTweets> inputList = new List<RawTweets> { new RawTweets { Id = "1", Language = "en", Text = "Trump sucks!" } };
            List<TweetsWithSentiment> outputList = new List<TweetsWithSentiment> { new TweetsWithSentiment { Id = 1, TweetId = "1", Language = "en", Text = "Trump sucks!", Sentiment = 0.00F } };

            Dissent.Services.SentimentApiService.RequestSentiment(inputList, outputList).Wait();

            Assert.AreNotEqual(null, outputList[0].Sentiment);
        } 
    }
}
