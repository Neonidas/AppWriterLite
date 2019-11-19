using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CSRocks.Controllers
{
    [Route("api/[controller]")]
    public class PredictionController : Controller
    {
        // GET api/values/5
        [HttpGet("en/{text}")]
        public async Task<string> GetENAsync(string text)
        {
            return await Predictions.GetPredictionsEnglish(text);   
        }

        // GET api/values/5
        [HttpGet("dk/{text}")]
        public async Task<string> GetDKAsync(string text)
        {
            return await Predictions.GetPredictionsDanish(text);
        }
    }
}
