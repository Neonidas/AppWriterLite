using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace CSRocks
{
    //Fetches predictions from predictions service
    public static class Client
    {
        public static HttpClient client = new HttpClient();

        public static void InitializeClient()
        {
            client.BaseAddress = new Uri("http://services.lingapps.dk");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                "MjAxOS0xMC0yOA==.bXIuc3RlZWxiQGdtYWlsLmNvbQ==.MjYzNDBjODgxMTdlNzBkZmFkNjM1NzUyZTE2Yjg4Yjg=");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<string> GetENPredictionsAsync(string text)
        {
            text = text.Replace(" ", "%20");
            text = "/misc/getPredictions?locale=en-GB&text=" + text;
            string prediction = await GetPredictionsAsync(text);
            return prediction;
        }

        public static async Task<string> GetDKPredictionsAsync(string text)
        {
            text = text.Replace(" ", "%20");
            text = "/misc/getPredictions?locale=da-DK&text=" + text;
            string prediction = await GetPredictionsAsync(text);
            return prediction;
        }

        private static async Task<string> GetPredictionsAsync(string request)
        {
            try
            {
                string prediction = await client.GetStringAsync(request);
                return prediction;
            } catch (Exception e)
            {
                Console.Error.WriteLine(
                    "There was an error while trying to GET predictions from web service");
                Console.Error.WriteLine(e.Message);
                await Console.Error.FlushAsync();
                return null;
            }
        }
    }
}