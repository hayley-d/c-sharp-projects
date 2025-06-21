using System.Collections;
using Newtonsoft.Json;
using LotrAPi;

namespace LotrApi {
    public class BookApi(string baseUrl)
    {
        private string Url { get; set; } = $"{baseUrl}/book";
        private Dictionary<string,string> Books { get; set; } = new Dictionary<string,string>();
        private static readonly HttpClient Client = new HttpClient();

        public async Task<IDictionary<string,string>> GetBooks(string apiKey) {
            try {
                Client.DefaultRequestHeaders.Add("Authorization",@"Bearer {apiKey}");
                var responseBody = await Client.GetAsync(this.Url);
                if(responseBody.IsSuccessStatusCode) {
                    var jsonBody = await responseBody.Content.ReadAsStringAsync();
                    BookResponse bookResponse = JsonConvert.DeserializeObject<BookResponse>(jsonBody) ?? new BookResponse();

                    foreach(var book in bookResponse.Books) {
                        Books.Add(book.Name,book.Id);
                    }

                    foreach(var pair in Books) {
                        Console.WriteLine($"Book name: {pair.Key}\nBook Id: {pair.Value}");
                    }
                } else {
                    Console.WriteLine($"Response Status code: {responseBody.StatusCode}");
                    throw new Exception("Unsuccessful api request");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return this.Books;
        }
    }
}
