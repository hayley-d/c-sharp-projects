using System.Collections;
using DotNetEnv;

namespace LotrApi {
    class Program {
        static async Task  Main(string[] _) {
            const string baseUrl = "https://the-one-api.dev/v2";
            try{
                Env.Load();
                IDictionary<string,string> secrets = Environment.GetEnvironmentVariables().Cast<DictionaryEntry>().
                    Where(entry => entry.Key.ToString() !=  "" && entry.Value is not null).ToDictionary(
                    entry => entry.Key.ToString() ?? "null",
                    entry => entry.Value?.ToString() ?? "default"
                    );
                if(string.IsNullOrEmpty(secrets["API_KEY"])) {
                    throw new Exception("Missing API key in environment file");
                }
                BookApi api = new BookApi(baseUrl);
                IDictionary<string,string> books = await api.GetBooks(secrets["API_KEY"]);
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Key} => {book.Value}");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

