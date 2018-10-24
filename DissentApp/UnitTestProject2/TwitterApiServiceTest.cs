using Dissent.Models;
using Dissent.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Logic;
using Tweetinvi.Models;

namespace DissentTest
{

    [TestClass]
    public class TwitterApiServiceTest
    {
        [TestMethod]
        public void Getting_Back_Tweets_From_API_With_TwitterInvi()
        {
            string input = "i";
            double lat = 59.3293;
            double lng = 18.0686;
            int radius = 50;

            List<ITweet> matchingTweets = TweetsApiService.GetTweets(input, lat, lng, radius);

            Assert.IsNotNull(matchingTweets);
        }

        //[TestMethod]
        //public void Populating_A_RawTweetList_With_ITweet_Input()
        //{
        //    Tweet t;
        //    var itweetList = new List<Tweet> { new Tweet { IdStr =  }
        //}; }

        [TestMethod]
        public void Converting_LanguageString_To_Sentiment_API_Language_Code_English()
        {
            var testList = new List<RawTweets> { new RawTweets { Language = "English" }};

            TweetsApiService.ConvertToLanguageCode(testList);

            Assert.AreEqual("en", testList[0].Language);

        }

        [TestMethod]
        public void Converting_LanguageString_To_Sentiment_API_Language_Code_Swedish()
        {
            var testList = new List<RawTweets> { new RawTweets { Language = "Swedish" }};

            TweetsApiService.ConvertToLanguageCode(testList);

            Assert.AreEqual("sv", testList[0].Language);

        }
    }
}
