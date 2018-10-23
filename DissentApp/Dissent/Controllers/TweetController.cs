using Dissent.Credentials;
using Dissent.Models;
using Dissent.Services;
using Dissent.wwwroot.Models;
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
  
        [HttpPost]
        public async Task<ActionResult> TwitterResult(string input)
        {
            List<ITweet> incomingTweets = TweetsApiService.GetTweets(input);

            List<Tweets> tweetsMiddleList = TweetsApiService.TweetsToTweetsModelList(incomingTweets);



            _context.AddRange(tweetsMiddleList);
            _context.SaveChanges();

            List<TweetsWithSentiment> tweetsFinalList = TweetsApiService.TweetsToTweetsWithSentimentModelList(incomingTweets);

            TweetsApiService.ConvertToLanguageCode(tweetsMiddleList);

            await SentimentApiService.RequestSentiment(tweetsMiddleList, tweetsFinalList);


            return Ok (tweetsFinalList);
        }
    }
}
