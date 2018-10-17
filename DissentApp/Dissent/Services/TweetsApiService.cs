//using Newtonsoft.Json;
//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;

//namespace Dissent.Services
//{
//    public class TweetsApiService
//    {
//        static async void MakeRequest(string input)
//        {
//            var client = new HttpClient();
//            //var queryString = HttpUtility.ParseQueryString("");

//            client.DefaultRequestHeaders.Add(@"authorization: OAuth oauth_consumer_key='consumer-key-for-app', oauth_nonce = 'generated-nonce', oauth_signature = 'generated-signature', oauth_signature_method = 'HMAC-SHA1', oauth_timestamp = 'generated-timestamp', oauth_token = 'access-token-for-authed-user', oauth_version = '1.0'");

//            string uri = $"https://api.twitter.com/1.1/search/tweets.json?q={input}&result_type=recent" /*+ queryString*/;

//            HttpResponseMessage response;

//            string inp = JsonConvert.SerializeObject(new { id = "1", language = "en", text = "Trump sucks!" });

//            byte[] byteData = Encoding.UTF8.GetBytes(inp);

//            using (var content = new ByteArrayContent(byteData))
//            {
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                response = await client.PostAsync(uri, content);

//                var result = await response.Content.ReadAsStringAsync();
//                Console.WriteLine(result);
//            }

//        }
//    }
//}
