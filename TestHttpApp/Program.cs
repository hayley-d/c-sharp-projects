using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TestHttpApp {
    class Program {
        static void Main(string[] args) {
            // Read all lines in the file into an array
            string[] inputLines = File.ReadAllLines("input.txt");

            foreach(string line in inputLines) {
                Console.WriteLine(line);
            }
        }
    }
}
