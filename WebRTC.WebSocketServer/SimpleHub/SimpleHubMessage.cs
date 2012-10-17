using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebRTC.WebSocketServer.SimpleHub
{
    public class SimpleHubMessage
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("users")]
        public IDictionary<string, string> Users { get; set; }
    }
}
