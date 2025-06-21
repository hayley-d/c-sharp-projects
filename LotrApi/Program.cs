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
                if(string.IsNullOrEmpty(secrets["API_KEY"])) {
                    throw new Exception("Missing API key in enviroment file");
                }

                Console.WriteLine(secrets["API_KEY"]);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

