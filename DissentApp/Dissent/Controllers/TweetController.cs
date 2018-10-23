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


        public TweetController(TweetsApiService tweetsApiService)
        {
            //_credentials = MyCredentials.GenerateCredentials();

            //Auth.SetCredentials(_credentials);
            _tweetsApiService = tweetsApiService;
        }

        public TweetsApiService _tweetsApiService;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TwitterResult(string input, double lat, double lng, int radius)
        {
            List<TweetsWithSentiment> tweetsFinalList = await _tweetsApiService.GetTweetsInRegion(input, lat, lng, radius);

            return Ok(tweetsFinalList);
        }
    }
}
