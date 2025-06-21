using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LotrApi;

namespace LotrApi {
    public class BookApi {
        public string url { get; set; }
        public Dictionary<string,string> books { get; set; } = new Dictionary<string,string>();
        static readonly HttpClient client = new HttpClient();

        public BookApi(string baseUrl) {
            this.url = $"{baseUrl}/book";
        }

        public async Task<IDictionary> GetBooks(string apiKey) {
            try {
                client.DefaultRequestHeaders.Add("Authorization",@"Bearer {apiKey}");
                var responseBody = await client.GetAsync(this.url);
                if(responseBody.IsSuccessStatusCode) {
                    var jsonBody = await responseBody.Content.ReadAsStringAsync();
                    var books = JsonConvert.DeserializeObject<BookResponse>(jsonBody);

                    foreach(var book in books) {
                        books.Add(book.Name,book.Id);
                    }

                    foreach(var pair in books) {
                        Console.WriteLine($"Book name: {pair.Key}\nBook Id: {pair.Value}");
                    }
                } else {
                    Console.WriteLine($"Response Satus code: {responseBody.StatusCode}");
                    throw new Exception("Unscuessful api request");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return this.books;
        }
    }
}
