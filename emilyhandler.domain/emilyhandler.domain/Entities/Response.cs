using Newtonsoft.Json;

namespace emilyhandler.Domain.Entities
{
    public class Response
    {
        [JsonProperty(nameof(Speech))]
        public string Speech { get; set; }

        [JsonProperty(nameof(DisplayText))]
        public string DisplayText { get; set; }

        [JsonProperty(nameof(Source))]
        public string Source { get; set; }
    }
}
