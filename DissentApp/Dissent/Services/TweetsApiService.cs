using Dissent.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                GeoCode = new GeoCode(59.3289, 18.0649, 15, DistanceMeasure.Kilometers),
                MaximumNumberOfResults = 5,
                Lang= LanguageFilter.Swedish

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
