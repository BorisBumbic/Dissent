using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace DissentTest
{
    [TestClass]
    public class TwitterApiServiceTest
    {
        [TestMethod]
        public void Getting_Back_Tweets_From_API_With_TwitterInvi()
        {
            string input = "jag";
            double lat = 59.3293;
            double lng = 18.0686;
            int radius = 50;

            var searchParameter = new SearchTweetsParameters(input)
            {
                MaximumNumberOfResults = 5,
                Lang = LanguageFilter.Swedish,
                SearchType = SearchResultType.Mixed, //vi måste titta på exakt vad 'recent' gör. ofta får man inte några resultat alls på rätt vanliga saker.//BB
                TweetSearchType = TweetSearchType.OriginalTweetsOnly, //jag la till endast original tweets//BB
                GeoCode = new GeoCode(lat, lng, radius, DistanceMeasure.Kilometers)
            };

            List<ITweet> matchingTweets = Search.SearchTweets(searchParameter).ToList();

            Assert.IsNotNull(matchingTweets);
        }
    }
}
