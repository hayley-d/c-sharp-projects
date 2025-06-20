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
                if(ValidateOrder(values)) {
                    safeReports += 1;
                }
            }

            Console.WriteLine("Safe Reports: " + safeReports);
        }

        static bool ValidateOrder(List<int> values) {
            try {
                if(values.Count < 2) {
                    throw new Exception("Invalid values length");
                } else {
                    bool increasing = false;

                    if(values[0] < values[1]) {
                        increasing = true;
                    } 

                    for(int i = 0; i < values.Count-1; i++) {
                        int diff = Math.Abs(values[i]-values[i+1]);

                        if(diff > 3 || diff == 0) {
                            return false;
                        }

                        if(increasing && values[i] > values[i+1]) {
                            return false;
                        }

                        if(!increasing && values[i] < values[i+1]) {
                            return false;
                        }
                    }

                    return true;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        
        static void PartTwo(string[] reports) {
        }
    }
}

