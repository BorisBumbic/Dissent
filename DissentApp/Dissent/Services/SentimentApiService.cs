using Dissent.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Dissent.Services
{
    public class SentimentApiService
    {
        public static async void RequestSentiment(List<Tweets> input, List<TweetsWithSentiment> sentimentList)
        {
            var client = new HttpClient();
            //var queryString = HttpUtility.ParseQueryString("");

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6712d8ff97cc46df9fff72c086d93709");

            var uri = "https://northeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?" /*+ queryString*/;

            HttpResponseMessage response;

            string inp = "{\"documents\":" + JsonConvert.SerializeObject(input) + "}";

            byte[] byteData = Encoding.UTF8.GetBytes(inp);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();
           
                for (int i = 0; i < sentimentList.Count; i++)
                {
                    //sentimentList[i].Sentiment = result[i].sentiment;

                }
            }

        }
    }
}
