using System;
using System.Collections;
using System.Linq;
using DotNetEnv;

namespace LotrApi {
    class Program {
        static void Main(string[] args) {
            const string BASE_URL = "https://the-one-api.dev/v2";
            try{
                Env.Load();
                IDictionary secrets = Environment.GetEnvironmentVariables();

                Console.WriteLine(secrets["API_KEY"]);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

