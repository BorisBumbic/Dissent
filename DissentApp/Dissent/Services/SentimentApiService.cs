using Dissent.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dissent.Services
{
    public class SentimentApiService
    {
        public static async Task RequestSentiment(List<Tweets> input, List<TweetsWithSentiment> sentimentList)
        {
            var client = new HttpClient();
          

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6712d8ff97cc46df9fff72c086d93709");

            var uri = "https://northeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?";

            HttpResponseMessage response;

            string inp = "{\"documents\":" + JsonConvert.SerializeObject(input) + "}";

            byte[] byteData = Encoding.UTF8.GetBytes(inp);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResponseData>(result);

                //Task<List<TweetsWithSentiment>> list = new Task<List<TweetsWithSentiment>>();
                for (int i = 0; i < Math.Min(sentimentList.Count, data.documents.Length); i++)
                {
                    sentimentList[i].Sentiment = data.documents[i].Score;
                }
                //return sentimentList;

            }
        }
    }
}
