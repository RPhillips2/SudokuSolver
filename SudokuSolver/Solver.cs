namespace SudokuSolver
{
    public class Solver
    {
        public int[][] startGrid = [];
        public int[][] solvedGrid =
        [
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9],
            new int[9]
        ];

        public int[][] get()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    solvedGrid[i][j] = 8;
                }
            }
            return solvedGrid;
        }
        public void set(int[][] intakeGrid)
        {
            startGrid = intakeGrid;
        }

    }
}
