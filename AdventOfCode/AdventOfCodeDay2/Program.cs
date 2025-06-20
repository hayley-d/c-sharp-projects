using System;
using System.Linq;
using System.Collections.Generic;


namespace AdventOfCodeDay2 {
    class Program {
        static void Main(string[] args) {
            try {
                if(args.Length == 0) {
                    string[] inputLines = File.ReadAllLines("input.txt");
                    PartOne(inputLines);
                    PartTwo(inputLines);
                } else {
                    string[] inputLines = File.ReadAllLines(args[0]);
                    PartOne(inputLines);
                    PartTwo(inputLines);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        
        static void PartOne(string[] reports){
            int safeReports = 0;
            foreach(string report in reports) {
                // Extract all value in report
                List<int> values = report.Split(" ").Select(x => Int32.Parse(x)).ToList();
                // Flags
                bool increasing = true;
                bool sorted = true;
                // Determine if increasing or decreasing
                if(values.Count > 2 && values[0] > values[1]) {
                    increasing = false;
                } else if(values.Count < 2) {
                    throw new Exception("Not enough reports to compare");
                }
                // Check if strictly increasing or decreasing
                for(int i = 0; i < values.Count-2; i++) {
                    int diff = Math.Abs(values[i] - values[i+1]);
                    if(increasing && values[i] > values[i+1]) {
                        sorted = false;
                        break;
                    } else if(!increasing && values[i] < values[i+1]) {
                        sorted = false;
                        break;
                    } 
                    // Diff can't be negative
                    if(diff > 3 || diff == 0) {
                        sorted = false;
                        break;
                    }
                }

                if(sorted) {
                    safeReports += 1;
                }
            }

            Console.WriteLine("Safe Reports: " + safeReports);
        }
        
        static void PartTwo(string[] reports) {
        }
    }
}

