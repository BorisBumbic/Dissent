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
        public string id { get; set; }
        public string text { get; set; }
        public string language { get; set; }

    }

    public class TweetsWithSentiment
    {
        public string id { get; set; }
        public string text { get; set; }
        public string language { get; set; }
        public decimal Sentiment { get; set; }
    }



    public class ResponseData
    {
        public Document[] documents { get; set; }
        public object[] errors { get; set; }
    }

    public class Document
    {
        public float score { get; set; }
        public string id { get; set; }
    }

}
