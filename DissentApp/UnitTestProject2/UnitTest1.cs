using Dissent.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            List<Tweets> inputList = new List<Tweets> { new Tweets { Id = "1", Language = "en", Text = "Trump sucks!" } };
            List<TweetsWithSentiment> outputList = new List<TweetsWithSentiment> { new TweetsWithSentiment { Id = "1", Language = "en", Text = "Trump sucks!", Sentiment = 0.00F } };

            await Dissent.Services.SentimentApiService.RequestSentiment(inputList, outputList);

            Assert.AreNotEqual(null, outputList[0].Sentiment);
        } 
    }
}
