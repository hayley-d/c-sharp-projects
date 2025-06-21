using LotrApi;
using Newtonsoft.Json;

namespace LotrAPi {
    public class BookResponse {
        [JsonProperty("docs")]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
