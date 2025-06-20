using System;
using System.Collections;
using System.Linq;
using DotNetEnv;

namespace LotrApi {
    class Program {
        static void Main(string[] args) {
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

