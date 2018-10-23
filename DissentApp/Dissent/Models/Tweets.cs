using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissent.Models
{
    public class Query
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public List<TweetsWithSentiment> SearchResults { get; set; }
    }

    public class RawTweets
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
    }

    public class TweetsWithSentiment
    {
        public int Id { get; set; }
        public string TweetId { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public float Sentiment { get; set; }

        [JsonIgnore]
        public Query SearchQuery { get; set; }
    }

    public class ResponseData
    {
        public Document[] documents { get; set; }
        public object[] Errors { get; set; }
    }

    public class Document
    {
        public float Score { get; set; }
        public string Id { get; set; }
    }
}
