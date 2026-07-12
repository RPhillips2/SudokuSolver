namespace SudokuSolver
{
    public class Cell
    {
        public int Row { get; }
        public int Column { get; }

        public int Value { get; set; }

        public HashSet<int> Candidates { get; } =
        [
            1,2,3,4,5,6,7,8,9
        ];

        public bool IsSolved => Value != 0;
    }
}
