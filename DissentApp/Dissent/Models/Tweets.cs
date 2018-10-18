using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissent.Models
{
    public class TweetList<Tweets>
    {

    }

    public class Tweets
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }

    }

    public class TweetsWithSentiment
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public decimal Sentiment { get; set; }
    }



    public class ResponseData
    {
        public Document[] Documents { get; set; }
        public object[] Errors { get; set; }
    }

    public class Document
    {
        public float Score { get; set; }
        public string Id { get; set; }
    }

}
