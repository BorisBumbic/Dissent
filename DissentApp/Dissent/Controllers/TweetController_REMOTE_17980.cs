using Dissent.Credentials;
using Dissent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Dissent.Controllers
{

    public class TweetController : Controller
    {
        private readonly ITwitterCredentials _credentials;

        public TweetController()
        {
            
            _credentials = MyCredentials.GenerateCredentials();

            Auth.SetCredentials(_credentials);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult TwitterResult(string input)
        //{
        //    var matchingTweets = Search.SearchTweets(input).First();
        //    //Tweet.

        //    return Ok(matchingTweets);
        //    //return View(matchingTweets);
        //}

        public List<Tweets> TwitterResult(string input)
        {
            var searchParameter = new SearchTweetsParameters(input)
            {
                GeoCode = new GeoCode(59.3289, 18.0649, 15, DistanceMeasure.Kilometers)
            };
            List<ITweet> matchingTweets = Search.SearchTweets(searchParameter).ToList();
            List<Tweets> tweetList = new List<Tweets>();
            foreach (var item in matchingTweets)
            {
                tweetList.Add(new Tweets
                {
                    id = item.IdStr,
                    text = item.FullText,
                    language = item.Language.ToString(),
                    

                });
                
                //Services.SentimentApiServices.RequestSentiment(tweetList);
            }
            return tweetList;
        }
    }
}
