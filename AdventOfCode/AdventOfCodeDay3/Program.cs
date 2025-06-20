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
            List<int> dos = new List<int>();
            List<int> donts = new List<int>();
            List<long> totals = new List<long>();

            //Start off enabled
            dos.Add(0);
            for(int i = 0;;i += "do()".Length) {
                int index = input.IndexOf("do()", i);
                if (index == -1) break;
                dos.Add(index);
            }

            for(int i = 0 ;; i += "don't()".Length) {
                int index  = input.IndexOf("don't()", i);
                if (index == -1) break;
                donts.Add(index);
            }

            
            for(int i = 0; i < donts.Count; i += 1) {
                if(i >= dos.Count) {
                    break;
                }
                int end = donts[i];
                int start = dos.Where(n => n < donts[i]).Last();
                totals.Add(Regex.Matches(input.Substring(start,end), @"mul\((\d{1,3}),(\d{1,3})\)").Select(m => long.Parse(m.Groups[1].Value) * long.Parse(m.Groups[2].Value)).Sum());

            }
        }
    }
}

