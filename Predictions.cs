using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSRocks
{
    /* Gets predictions from Dictionary.db and web service
     * and returns results as Json arrays.
     */
    public class Predictions
    {

        public static async Task<string> GetPredictionsDanish(string text)
        {
            string WebServicePredictionsJSON = await Client.GetDKPredictionsAsync(text);
            List<string> DbPredictions = await DataBaseHandler.GetWordsLike(GetLastWord(text));

            JArray BothPredictionArrays = new JArray
            {
                JArray.FromObject(DbPredictions.ToArray()),
                JArray.Parse(WebServicePredictionsJSON)
            };


            return BothPredictionArrays.ToString();
        }

        public static async Task<string> GetPredictionsEnglish(string text)
        {
            string WebServicePredictionsJSON = await Client.GetENPredictionsAsync(text);

            return WebServicePredictionsJSON;
        }

        private static string GetLastWord(string text)
        {
            Regex lastwordreg = new Regex(@"\b(\w+)$");

            return lastwordreg.Match(text).Value;
        }
    }
}
