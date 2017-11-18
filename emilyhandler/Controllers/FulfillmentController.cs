using System.Threading.Tasks;
using emilyhandler.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace emilyhandler.Controllers
{
    [Route("api/[controller]")]
    public class FulfillmentController : Controller
    {
        private readonly IEmilyHandler _emilyHandler;

        public FulfillmentController(IEmilyHandler emilyHandler)
        {
            _emilyHandler = emilyHandler;
        }

        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JObject request)
        {
            // Deserialize the JSON from the request
            var deJson = _emilyHandler.Deserialize(request.ToString());

            // setup the Emily Handler
            _emilyHandler.Setup();

            // setup generic response
            var genericResponse = await _emilyHandler.CreateIntroResponse();

            // get request category
            var requestCategory = await _emilyHandler.DetermineRequestCategory(deJson.Result.Parameters);

            // call the appropriate handler for the request category
            var requestResult =  _emilyHandler.Answer(requestCategory, genericResponse);

            return Ok(requestResult);
        }
    }
}
