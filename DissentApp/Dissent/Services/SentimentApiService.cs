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
        public static async void RequestSentiment(List<Tweets> input)
        {
            var client = new HttpClient();
            //var queryString = HttpUtility.ParseQueryString("");

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6712d8ff97cc46df9fff72c086d93709");

            var uri = "https://northeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?" /*+ queryString*/;

            HttpResponseMessage response;

            string inp = JsonConvert.SerializeObject(input);

<<<<<<< HEAD
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

            //string inp = JsonConvert.SerializeObject(r);

            //byte[] byteData = Encoding.UTF8.GetBytes(inp);

            //using (var content = new ByteArrayContent(byteData))
            //{
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    response = await client.PostAsync(uri, content);

            //    var result = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(result);
            //}
=======
            byte[] byteData = Encoding.UTF8.GetBytes(inp);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
>>>>>>> e0eaa222d80a845bde0e3950973e332cc83e8a93

        }
    }
}
