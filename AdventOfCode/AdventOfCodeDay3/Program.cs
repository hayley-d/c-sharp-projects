using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeDay3 {
    class Program {
        static void Main(string[] args) {
            try{
                if(args.Length > 0) {
                   string input = File.ReadAllText(args[0]);
                   PartOne(input);
                   PartTwo(input);
                } else {
                    throw new Exception("No file name included in command line args");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void PartOne(string input) {
            try {
                long total = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)").Select(m => long.Parse(m.Groups[1].Value) * long.Parse(m.Groups[2].Value)).Sum();
                Console.WriteLine(total);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void PartTwo(string input) {
        }
    }
}

