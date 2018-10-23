using Dissent.Models;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Dissent.Services
{
    public class TweetsApiService
    {
        public static List<ITweet> GetTweets(string input, double lat, double lng, int radius)
        {
            var searchParameter = new SearchTweetsParameters(input)
            {
                MaximumNumberOfResults =5,
                //Lang= LanguageFilter.Swedish,
                SearchType = SearchResultType.Recent,
                TweetSearchType = TweetSearchType.OriginalTweetsOnly,
                GeoCode = new GeoCode(lat, lng, radius, DistanceMeasure.Kilometers)
            };

            List<ITweet> matchingTweets = Search.SearchTweets(searchParameter).ToList();
            return matchingTweets;
        }
        

        public static List<Tweets> TweetsToTweetsModelList(List<ITweet> matchingTweets)
        {
            List<Tweets> tweetList = new List<Tweets>();
            List<TweetsWithSentiment> sentimentList = new List<TweetsWithSentiment>();
            foreach (var item in matchingTweets)
            {
                if(item.Language == Language.English || item.Language == Language.Swedish)
                tweetList.Add(new Tweets
                {
                    Id = item.IdStr,
                    Text = item.FullText,
                    Language = item.Language.ToString(),
                });

            }
            return tweetList;
        }

        public static List<TweetsWithSentiment> TweetsToTweetsWithSentimentModelList(List<ITweet> matchingTweets)
        {
            List<TweetsWithSentiment> sentimentList = new List<TweetsWithSentiment>();
            foreach (var item in matchingTweets)
            {
                sentimentList.Add(new TweetsWithSentiment
                {
                    Id = item.IdStr,
                    Text = item.FullText,
                    Language = item.Language.ToString(),
                });

            }
            return sentimentList;
        }

        public static void ConvertToLanguageCode(List<Tweets> tweetList)
        {
            foreach (var item in tweetList)
            {
                if (item.Language == "English")
                    item.Language = "en";
                if (item.Language == "Swedish")
                    item.Language = "sv";
            }
        }
    }
}
