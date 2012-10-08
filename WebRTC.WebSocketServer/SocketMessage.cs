using Newtonsoft.Json;

namespace WebRTC.WebSocketServer
{
    public class SocketMessage
    {
        [JsonProperty("clientid")]
        public string ClientId { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("mtype")]
        public string MType { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("sndr")]
        public string Sndr { get; set; }

        [JsonProperty("rcpt")]
        public string Rcpt { get; set; }

        [JsonProperty("jsepdata")]
        public string JsepData { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("cand")]
        public string Cand { get; set; }
    }
}