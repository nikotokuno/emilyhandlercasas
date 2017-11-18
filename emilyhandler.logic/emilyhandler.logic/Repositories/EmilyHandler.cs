using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emilyhandler.domain.Entities;
using emilyhandler.Domain.Entities;
using emilyhandler.Domain.Interfaces;
using emilyhandler.Domain.Static_Constants;
using emilyhandler.Domain.Value_Objects;
using emilyhandler.persistance.Models;
using InfluxDB.Net;
using InfluxDB.Net.Models;
using Newtonsoft.Json;
using Vibrant.InfluxDB.Client;

namespace emilyhandler.logic.Repositories
{
    public class EmilyHandler : IEmilyHandler
    {
        private InfluxClient _influxDb;
        private List<Serie> _series;

        public Root RootObject { get; set; }


        public async void Setup()
        {

        }

        public Root Deserialize(string json)
        {
            // Get the JSON from body and convert to a dynamic object
            dynamic query = JsonConvert.DeserializeObject(json);

            // Get the parameters from the JSON
            Dictionary<string, string> b = JsonConvert.DeserializeObject<Dictionary<string, string>>(query.result.parameters.ToString());

            // Set the parameters property of the root object
            var obj = JsonConvert.DeserializeObject<Root>(json);
            obj.Result.Parameters.Params = new Dictionary<string, string>();
            obj.Result.Parameters.Params = b;

            // return the root object with all properties set.
            return obj;
        }

        public async Task<RequestCategory> DetermineRequestCategory(domain.Entities.Parameters requestParams)
        {
            // Get the keys from the parameters in the results object from the JSON request
            var keys = requestParams.Params.Keys;

            // Check and match the parameter keywords to the keyword(s) supported by Emily
            var action = keys.First(k => KeywordList.Keywordlist.ContainsKey(k));

            // Categorize the request parameter
            var category = Enum.Parse<RequestCategory>(action);

            // Return the category
            return category;
        }

        public async Task<Response> CreateIntroResponse()
        {
            var res = new Response()
            {
                Speech = "Welcome to Emily Home!",
                DisplayText = "Welcome to Emily Home!",
                Source = "Emily"
            };

            return res;
        }

        public async Task<Response> Answer(RequestCategory category, Response response)
        {
            _influxDb = new InfluxClient(new Uri("http://influx.shpr.pw:8086"), "casasadmin", "pw4adminemily");
            var resultSet = await _influxDb.ReadAsync<SiteEvent>("homes.autogen", "SELECT * FROM homes.autogen.site_event WHERE time > now() - 24h");

            var result = resultSet.Results[0];

            var series = result.Series[0];

            // get the redis/influx tag from the keyword dictionary
            var action = KeywordList.Keywordlist[category.ToString()];

            var res = new Response();
            var dbResponseString = "";

            foreach (var row in series.Rows)
            {
                var resultText = row.Event.Contains(action)
                    ? row.Value
                    : null;

                if (resultText != null)
                {
                    res.DisplayText = res.Speech =
                        "The resident has " + action;
                    res.Source = "Emily";

                    return res;
                }

            }


            res.DisplayText = res.Speech =
                "Te resident has not " + action;
            res.Source = "Emily";

            return res;
        }
    }
}
