using System;
using System.Collections.Generic;
using System.IO;

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
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
