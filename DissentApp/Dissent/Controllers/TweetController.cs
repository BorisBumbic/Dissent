﻿using Dissent.Credentials;
using Dissent.Models;
using Dissent.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ActionResult TwitterResult(string input)
        { 


            List<ITweet> a = TweetsApiService.GetTweets(input);

            List<Tweets> b = TweetsApiService.TweetsToTweetsModelList(a);

            List<TweetsWithSentiment> c = TweetsApiService.TweetsToTweetsWithSentimentModelList(a);

            TweetsApiService.ConvertToLanguageCode(b);

            SentimentApiService.RequestSentiment(b,c);



       
            return Ok(c);
        }
    }
}
