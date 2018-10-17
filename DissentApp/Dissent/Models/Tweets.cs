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
        public decimal sentiment { get; set; }


    }
}
