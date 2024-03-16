namespace MorpionApp
{
    public class Grid<T>
    {
        private T[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new T[rows, columns];
        }

        public T GetValue(int row, int column)
        {
            return grid[row, column];
        }

        public void SetValue(int row, int column, T value)
        {
            grid[row, column] = value;
        }

        public void SetGrid(T[,] newGrid)
        {
            grid = newGrid;
        }
        
        public void Print() {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(grid[i, j]?.ToString() ?? " ");
                    if (j < Columns - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                if (i < Rows - 1)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        Console.Write("-");
                        if (j < Columns - 1)
                        {
                            Console.Write("+");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public bool IsFree(int row, int column)
        {
            if (typeof(T) == typeof(char))
            {
                return grid[row, column] == null;
            }
            else
            {
                return grid[row, column].Equals(default(T));
            }
        }

        public bool IsFull()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (grid[i, j] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}