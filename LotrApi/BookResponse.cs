using LotrApi;
using Newtonsoft.Json;

namespace LotrAPi {
    public class BookResponse {
        [JsonProperty("docs")]
        public List<Book> books { get; set; } = new List<Book>();
    }
}
