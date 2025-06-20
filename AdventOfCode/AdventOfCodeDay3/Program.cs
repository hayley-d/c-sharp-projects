using System;
using System.Linq;

namespace AdventOfCodeDay3 {
    class Program {
        static void Main(string[] args) {
            try{
                if(args.Length > 0) {
                   string input = File.ReadAllText(args[0]);
                   PartOne(input.ToCharArray());
                   PartTwo(input);
                } else {
                    throw new Exception("No file name included in command line args");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void PartOne(char[] input) {
            try {
                List<char> buffer = new List<char>();
                List<int> answers = new List<int>();

                for(int i = 0; i < input.Length; i++) {
                   if (input[i] is 'm') {
                        bool isCorrectSyntax = true;
                        int num1 = 0;
                        int num2 = 0;
                        if(input[i+1] is 'u' && input[i+2] is'l' && input[i+3] is '(') {
                            i += 4;
                            while(isCorrectSyntax && i < input.Length) {
                                if(Char.IsDigit(input[i])) {
                                    buffer.Add(input[i]); 
                                } else if (input[i] is ',') {
                                    break;
                                } else {
                                    isCorrectSyntax = false;
                                    break;
                                }
                                i += 1;
                            }

                            if (isCorrectSyntax) {
                                num1 = Int32.Parse(new string(buffer.ToArray()));
                                buffer = new List<char>();

                                while(isCorrectSyntax && i < input.Length) {
                                    if(Char.IsDigit(input[i])) {
                                        buffer.Add(input[i]); 
                                    } else if (input[i] is ')') {
                                        break;
                                    } else {
                                        isCorrectSyntax = false;
                                        break;
                                    }
                                    i += 1;
                                }

                                if (isCorrectSyntax) {
                                    Console.WriteLine(num2);
                                    num2 = Int32.Parse(new string(buffer.ToArray()));
                                    answers.Add(num1 * num2);
                                    continue;
                                } else {
                                    continue;
                                }
                            } else {
                                continue;
                            }
                        }
                   } else {
                       continue;
                   }
                }
                int total = answers.Sum();
                Console.WriteLine("Sum of multiplication: " + total);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void PartTwo(string input) {
        }
    }
}

