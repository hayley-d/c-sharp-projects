
namespace AdventOfCodeDay6 {
    class Program {
        public static void Main(string[] args) {
            try {
                if(args.Length < 1) {
                    throw new Exception("No input file provided in command line arguments");
                }

                int[] dimensions = GetDimensions(args[0]);

                Board board = new Board(dimensions[0],dimensions[1]);
                board.PopulateBoard(args[0]);
            } catch (Exception ex) {
                Console.WriteLine($"Error Occured: {ex.Message}");
            }
        }

        public static int[] GetDimensions(string fileName) {
            int[] dimensions = new int[2];
            try {
                string[] lines = File.ReadAllLines(fileName);
                if(lines.Length < 1) {
                    throw new Exception("File matrix is invalid length");
                }
                int rows = lines.Length;
                int cols = lines[0].Length;
                dimensions[0] = rows;
                dimensions[1] = cols;
            } catch (Exception ex) {
                Console.WriteLine($"Dimensions Error: {ex.Message}");
            }
            return dimensions;
        }
    }
}
