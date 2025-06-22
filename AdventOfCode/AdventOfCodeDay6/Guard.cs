namespace AdventOfCodeDay6 {
    public class Guard (char symbol, int xCoord, int yCoord, Board board) {
        public char Symbol { get; private set; } = symbol;
        public int XCoord { get; private set; } = xCoord;
        public int YCoord { get; private set; } = yCoord;

        // Reference to the game board
        private Board Board { get; set; } = board;
        
        // Always returns a pair of coordinates
        public int[] StepForward() {
            int[] coords = new int[2];
            
            return coords;
        }
    }
}
