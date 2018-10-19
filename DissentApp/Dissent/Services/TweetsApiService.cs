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
        public static List<ITweet> GetTweets(string input)
        {
            var searchParameter = new SearchTweetsParameters(input)
            {
<<<<<<< HEAD
              
                
=======
                SearchType = SearchResultType.Recent,
>>>>>>> 3200466748bf21cfb9f8ec2b32a47e7b6ed02849
                MaximumNumberOfResults = 20,
                Lang= LanguageFilter.English,
                TweetSearchType = TweetSearchType.OriginalTweetsOnly,
<<<<<<< HEAD
                SearchType = SearchResultType.Recent,


=======
                GeoCode = new GeoCode(10.00000, 10.0000, 15, DistanceMeasure.Kilometers)
>>>>>>> 3200466748bf21cfb9f8ec2b32a47e7b6ed02849
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
                    id = item.IdStr,
                    text = item.FullText,
                    language = item.Language.ToString(),
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
                    id = item.IdStr,
                    text = item.FullText,
                    language = item.Language.ToString(),
                });

            }
            return sentimentList;
        }

        public static void ConvertToLanguageCode(List<Tweets> tweetList)
        {
            foreach (var item in tweetList)
            {
                if (item.language == "English")
                    item.language = "en";
                if (item.language == "Swedish")
                    item.language = "sv";
            }
        }
    }
}
