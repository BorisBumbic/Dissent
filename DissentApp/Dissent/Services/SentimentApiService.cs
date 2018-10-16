using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Dissent.Services
{
    public class SentimentApiService
    {
        static async void MakeRequest(string input)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6712d8ff97cc46df9fff72c086d93709");

            var uri = "https://northeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?" + queryString;

            HttpResponseMessage response;


            //var r = new RootObject
            //{
            //    documents = new List<Document>
            //    {
            //       new Document
            //       {
            //           text=input,
            //           language="en",
            //           id="1"
            //       },
            //        new Document
            //       {
            //           text="Trump bla bla",
            //           language="en",
            //           id="2"
            //       },

            //    }
            //};

            string inp = JsonConvert.SerializeObject(r);  

            byte[] byteData = Encoding.UTF8.GetBytes(inp);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }

        }
    }
}
