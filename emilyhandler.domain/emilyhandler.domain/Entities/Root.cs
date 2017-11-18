using System.Collections.Generic;
using Newtonsoft.Json;

namespace emilyhandler.domain.Entities
{
    public partial class Root
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    public class Status
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }

        [JsonProperty("webhookTimedOut")]
        public bool WebhookTimedOut { get; set; }
    }

    public class Result
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty("contexts")]
        public List<object> Contexts { get; set; }

        [JsonProperty("fulfillment")]
        public Fulfillment Fulfillment { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("parameters")]
        public Dictionary<string, string> Params { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("intentId")]
        public string IntentId { get; set; }

        [JsonProperty("intentName")]
        public string IntentName { get; set; }

        [JsonProperty("webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }

        [JsonProperty("webhookResponseTime")]
        public long WebhookResponseTime { get; set; }

        [JsonProperty("webhookUsed")]
        public string WebhookUsed { get; set; }
    }

    public class Fulfillment
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("speech")]
        public string Speech { get; set; }
    }

    public class Message
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public partial class Root
    {
        public static Root FromJson(string json) => JsonConvert.DeserializeObject<Root>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Root self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
