﻿using Dissent.Credentials;
using Dissent.Models;
using Dissent.Services;
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
        public async Task<ActionResult> TwitterResult(string input)
        {
            List<ITweet> incomingTweets = TweetsApiService.GetTweets(input);

            List<Tweets> tweetsMiddleList = TweetsApiService.TweetsToTweetsModelList(incomingTweets);

            List<TweetsWithSentiment> tweetsFinalList = TweetsApiService.TweetsToTweetsWithSentimentModelList(incomingTweets);

            TweetsApiService.ConvertToLanguageCode(tweetsMiddleList);

            await SentimentApiService.RequestSentiment(tweetsMiddleList, tweetsFinalList);

<<<<<<< HEAD


            return View(tweetsFinalList);




=======
            return View(tweetsFinalList);
>>>>>>> 55553375ec77cc6d76a0c3803ed1354aa3ec1129
        }
    }
}
