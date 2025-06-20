using System;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LotrApi {
    class BookApi {
        public string url { get; set; }
        public IDictionary books { get; set; }
        static readonly HttpClient client = new HttpClient();

        public BookApi(string baseUrl) {
            this.url = $"{baseUrl}/book";
        }

        public async GetBooks() {
            var response = await client.GetAsync(this.url);
            if(response.IsSuccessStatuscode) {
            } else {
            }
            client.Dispose();
        }
    }
}
