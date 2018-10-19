using Dissent.Credentials;
using Dissent.Models;
using Dissent.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        //public IActionResult TwitterResult(string input)
        //{
        //    var searchParameter = new SearchTweetsParameters(input)
        //    {


        //        MaximumNumberOfResults = 20,
        //        Lang = LanguageFilter.English,
        //        GeoCode=new GeoCode(38.897,-77.038 ,10, DistanceMeasure.Kilometers)
        //        //TweetSearchType = TweetSearchType.OriginalTweetsOnly,
        //        // SearchType = SearchResultType.Recent,


        //    };
        //    List<ITweet> matchingTweets = Search.SearchTweets(searchParameter).ToList();

        //    //var v = new List<string>();
        //    //foreach (var item in matchingTweets)
        //    //{
        //    //    v.Add(item.FullText.ToString());


        //    //}

        //    return Ok(matchingTweets);
        //}

        [HttpGet]
        public async Task<ActionResult> TwitterResult(string input)
        {


            List<ITweet> incomingTweets = TweetsApiService.GetTweets(input);

            List<Tweets> tweetsMiddleList = TweetsApiService.TweetsToTweetsModelList(incomingTweets);

            List<TweetsWithSentiment> tweetsFinalList = TweetsApiService.TweetsToTweetsWithSentimentModelList(incomingTweets);

            TweetsApiService.ConvertToLanguageCode(tweetsMiddleList);

            await SentimentApiService.RequestSentiment(tweetsMiddleList, tweetsFinalList);
<<<<<<< HEAD


               return Ok(tweetsFinalList);



            //}



=======

            return Ok();
>>>>>>> 3200466748bf21cfb9f8ec2b32a47e7b6ed02849
        }
    }
}
