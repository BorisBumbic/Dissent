using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace Dissent.Credentials
{
    public static class MyCredentials
    {
        public static string CONSUMER_KEY = "50e2ilSWj96vbTXA9a0jDDt8p";
        public static string CONSUMER_SECRET = "RKW1jd3K1gVtgMq0ZFFKiZzCmVISiEn75OvOojZO3QVu7vbM9q";
        public static string ACCESS_TOKEN = "806173448439373824-0Ui27il7qpQZ2QrtosX0mR0AP6cpzAf";
        public static string ACCESS_TOKEN_SECRET = "79XOi500yvm7SsRI2fHCYaDTzVP5WvTjh8Yl3X17lVqjR";

        public static ITwitterCredentials GenerateCredentials()
        {
            return new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
        }
    }
}
