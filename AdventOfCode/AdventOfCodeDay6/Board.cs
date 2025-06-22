
namespace AdventOfCodeDay6 {
    public class Board {
        public char[][] GameBoard { get; set; }
        public int Width { get; set; } 
        public int Height { get; set; }

        public Board(int rows, int cols) {
            this.Width = rows;
            this.Height = cols;
            this.GameBoard = new char[rows][];
            for(int row = 0; row < rows; row++) {
                this.GameBoard[row] = new char[cols];
            }
        }

        public void PopulateBoard(string fileName) {
            string[] lines = File.ReadAllLines(fileName);
            int currentRow = 0; 
            foreach(string line in lines) {
                char[] symbols = line.ToCharArray();

                int col = 0;
                while(col < symbols.Length && currentRow < this.Width && col < this.Height) {
                    this.GameBoard[currentRow][col] = symbols[col]; 
                    col += 1;
                }
                currentRow += 1;
            }
        }


        public void PrintBoard() {
            for(int row = 0; row < this.Width; row += 1) {
                for(int col = 0; col < this.Height; col += 1) {
                    Console.Write(this.GameBoard[row][col]);
                }
                Console.Write('\n');
            }
        }

    }
}
