using Dissent.Credentials;
using Dissent.Models;
using Dissent.Services;
using Dissent.wwwroot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace Dissent.Controllers
{

    public class TweetController : Controller
    {
        private readonly ITwitterCredentials _credentials;
        private readonly TwitterDbcontext _context;

        public TweetController(TwitterDbcontext context)
        {
            _credentials = MyCredentials.GenerateCredentials();

            Auth.SetCredentials(_credentials);
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
  
        

       

        [HttpGet]
        public async Task<ActionResult> TwitterResult(string input, double lat, double lng, int radius)
        {
            List<ITweet> incomingTweets = TweetsApiService.GetTweets(input, lat, lng, radius);

            List<Tweets> tweetsMiddleList = TweetsApiService.TweetsToTweetsModelList(incomingTweets);

            List<TweetsWithSentiment> tweetsFinalList = TweetsApiService.TweetsToTweetsWithSentimentModelList(incomingTweets);

            TweetsApiService.ConvertToLanguageCode(tweetsMiddleList);

            await SentimentApiService.RequestSentiment(tweetsMiddleList, tweetsFinalList);

            _context.AddRange(tweetsFinalList);
            _context.SaveChanges();


            return Ok(tweetsFinalList);
           
        }
    }
}
