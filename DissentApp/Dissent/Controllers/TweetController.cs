using Dissent.Credentials;
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

        [HttpPost]
        public ActionResult TwitterResult(string input)
        {
            var searchParameter = new SearchTweetsParameters(input)
            {
                GeoCode = new GeoCode(59.3289, 18.0649, 15, DistanceMeasure.Kilometers),
                Lang = LanguageFilter.English,
                MaximumNumberOfResults = 5

                //    SearchType = SearchResultType.Popular,
                //    MaximumNumberOfResults = 100,
                //    Until = new DateTime(2015, 06, 02),
                //    SinceId = 399616835892781056,
                //    MaxId = 405001488843284480,
                //    Filters = TweetSearchFilters.Images
            };
            var result = Search.SearchTweets(searchParameter);//.FirstOrDefault();
            //return Ok(result);
            return View(result);
        }
    }
}
