using Dissent.Credentials;
using Dissent.Models;
using Dissent.wwwroot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Dissent.Services
{
    public class TweetsApiService
    {
        //private readonly ITwitterCredentials _credentials;
        private readonly TwitterDbcontext _context;
        private readonly ITwitterCredentials _credentials;

        public TweetsApiService(TwitterDbcontext context)
        {
            _context = context;
            _credentials = MyCredentials.GenerateCredentials();

            Auth.SetCredentials(_credentials);
        }

        public static List<ITweet> GetTweets(string input, double lat, double lng, int radius)
        {
            var searchParameter = new SearchTweetsParameters(input)
            {
                MaximumNumberOfResults =5,
                Lang= LanguageFilter.Swedish,
                SearchType = SearchResultType.Recent,
                TweetSearchType = TweetSearchType.All,
                GeoCode = new GeoCode(lat, lng, radius, DistanceMeasure.Kilometers)
            };

            List<ITweet> matchingTweets = Search.SearchTweets(searchParameter).ToList();
            return matchingTweets;
        }
        
        public static List<RawTweets> TweetsToTweetsModelList(List<ITweet> matchingTweets)
        {
            List<RawTweets> tweetList = new List<RawTweets>();
            List<TweetsWithSentiment> sentimentList = new List<TweetsWithSentiment>();
            foreach (var item in matchingTweets)
            {
                tweetList.Add(new RawTweets
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
                    TweetId = item.IdStr,
                    Text = item.FullText,
                    Language = item.Language.ToString(),
                });
            }
            return sentimentList;
        }

        public static void ConvertToLanguageCode(List<RawTweets> tweetList)
        {
            foreach (var item in tweetList)
            {
                if (item.Language == "English")
                    item.Language = "en";
                if (item.Language == "Swedish")
                    item.Language = "sv";
            }
        }

        public async Task<List<TweetsWithSentiment>> GetTweetsInRegion(string input, double lat, double lng, int radius)
        {
            List<ITweet> incomingTweets = GetTweets(input, lat, lng, radius);

            List<RawTweets> tweetsMiddleList = TweetsToTweetsModelList(incomingTweets);

            List<TweetsWithSentiment> tweetsFinalList = TweetsToTweetsWithSentimentModelList(incomingTweets);

            ConvertToLanguageCode(tweetsMiddleList);

            await SentimentApiService.RequestSentiment(tweetsMiddleList, tweetsFinalList);

            SaveQueryAndResponseToDb(tweetsFinalList, input);

            return tweetsFinalList;
        }

        private void SaveQueryAndResponseToDb(List<TweetsWithSentiment> tweetsFinalList, string input)
        {
            var query = new Query { SearchQuery = input };
            query.SearchResults = tweetsFinalList;
            _context.Query.Add(query);
            _context.SaveChanges();
        }
    }
}
