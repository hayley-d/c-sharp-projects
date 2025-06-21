using Newtonsoft.Json;

namespace LotrApi {
    public class Book {
        [JsonProperty("_id")]
        public string id { get; set; } = "";
        [JsonProperty("name")]
        public string name { get; set; } = "";
    }
}
