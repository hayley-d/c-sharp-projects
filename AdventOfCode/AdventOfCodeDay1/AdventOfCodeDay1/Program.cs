using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                List<int> col1 = new List<int>();
                List<int> col2 = new List<int>();

                List<int> diffs = new List<int>();
                string[] lines  = File.ReadAllLines("input.txt");
                foreach (string line in lines)
                {
                    string[] StringNumbers = line.Split("   ");
                    if (StringNumbers.Length == 2) {
                        col1.Add(Int32.Parse(StringNumbers[0]));
                        col2.Add(Int32.Parse(StringNumbers[1]));
                    } else {
                        throw new CustomException("Invalid array length");
                    }
                }

                //Sort the lists
                col1.Sort();
                col2.Sort();

                for (int i = 0; i < col1.Count; i++) {
                    diffs.Add(Math.Abs(col1[i] - col2[i]));
                }

                int total = 0;
                foreach(int diff in diffs) {
                    total += diff;
                }
                Console.WriteLine(total);
                Console.WriteLine("Starting Phase 2");
                PartTwo(lines);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void PartTwo(string[] inputLines) {
            try{
                List<int> col1 = new List<int>();
                List<int> col2 = new List<int>();

                foreach(string line in inputLines) {
                    string[] numbers = line.Split("   ");

                    if(numbers.Length == 2) {
                        col1.Add(Int32.Parse(numbers[0]));
                        col2.Add(Int32.Parse(numbers[1]));
                    } else {
                        throw new CustomException("Invalid Array Length Part 2");
                    }
                }

                var counts = col1.Distinct().Select(x => new {
                        Value = x,
                        Count = col2.Count(y => y==x)
                });

                int similarityScore = 0;
                foreach(var assesment in counts) {
                    similarityScore += (assesment.Value * assesment.Count);
                }

                Console.WriteLine(similarityScore);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
