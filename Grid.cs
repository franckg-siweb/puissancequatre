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

    }
}