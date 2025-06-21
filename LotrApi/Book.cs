using Newtonsoft.Json;

namespace LotrApi {
    public class Book {
        [JsonProperty("_id")]
        public string Id { get; set; } = "";
        [JsonProperty("name")]
        public string Name { get; set; } = "";
    }
}
