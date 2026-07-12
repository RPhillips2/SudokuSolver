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

        public Cell[][] cells =
        [
            new Cell[9],
            new Cell[9],
            new Cell[9],
            new Cell[9],
            new Cell[9],
            new Cell[9],
            new Cell[9],
            new Cell[9],
            new Cell[9]
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
        public int[][] Solve(int[][] board)
        {
            startGrid = board;

            Initialise();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    solvedGrid[i][j] = cells[i][j].Value;
                }
            }

            bool solved = false;
            bool imPossible = false;

            while (!solved && !imPossible)
            {

            }
                       
            return solvedGrid;
        }

        public void Initialise()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i][j] = new Cell();
                    cells[i][j].Value = startGrid[i][j];

                }
            }
        }

        public bool CheckCandidates()
        {
            bool updated = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i][j].Candidates.Count == 1)
                    {
                        cells[i][j].Value = cells[i][j].Candidates.First();

                        updated = true;
                    }
                }
            }

            return updated;
        }

        public bool CheckIfSolved()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i][j].IsSolved == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool UpdateCandidates()
        {
            bool updated = false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i][j].IsSolved)
                    {
                        for (int i2 = 0; i2 < 9; i2++)
                        {
                            if (!updated && cells[i2][j].Candidates.Contains(cells[i][j].Value))
                            {
                                updated = true;
                            }
                            cells[i2][j].Candidates.Remove(cells[i][j].Value);
                        }
                        for (int j2 = 0; j2 < 9; j2++)
                        {
                            if (!updated && cells[i][j2].Candidates.Contains(cells[i][j].Value))
                            {
                                updated = true;
                            }
                            cells[i][j2].Candidates.Remove(cells[i][j].Value);
                        }

                        int iMin = 6;
                        int jMin = 6;

                        if (i < 3)
                        {
                            iMin = 0;
                        }
                        else if (i < 6)
                        {
                            iMin = 3;
                        }

                        if (j < 3)
                        {
                            jMin = 0;
                        }
                        else if (j < 6)
                        {
                            jMin = 3;
                        }
                        for (int i2 = iMin; i2 < iMin + 3; i2++)
                        {
                            for (int j2 = jMin; j2 < jMin + 3; j2++)
                            {
                                if (!updated && cells[i2][j2].Candidates.Contains(cells[i][j].Value))
                                {
                                    updated = true;
                                }
                                cells[i2][j2].Candidates.Remove(cells[i][j].Value);
                            }
                        }                        
                    }
                }
            }

            return updated;
        }
    }
}
