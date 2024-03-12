namespace MorpionApp;

public class LinearEvaluator
{

    public static int LonguestLine(Grid<char> grid, char c) {
        int maxCount = 0;

        // Check horizontally
        for (int row = 0; row < grid.Rows; row++) {
            int count = 0;
            for (int col = 0; col < grid.Columns; col++) {
                if (grid.GetValue(row, col) == c) {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else {
                    count = 0;
                }
            }
        }

        // Check vertically
        for (int col = 0; col < grid.Columns; col++) {
            int count = 0;
            for (int row = 0; row < grid.Rows; row++) {
                if (grid.GetValue(row, col) == c) {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else {
                    count = 0;
                }
            }
        }

        // Check diagonally (top-left to bottom-right)
        for (int row = 0; row < grid.Rows; row++) {
            for (int col = 0; col < grid.Columns; col++) {
                int count = 0;
                int r = row;
                int column = col;
                while (r < grid.Rows && column < grid.Columns && grid.GetValue(r, column) == c) {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                    r++;
                    column++;
                }
            }
        }

        // Check diagonally (top-right to bottom-left)
        for (int row = 0; row < grid.Rows; row++) {
            for (int col = grid.Columns - 1; col >= 0; col--) {
                int count = 0;
                int r = row;
                int column = col;
                while (r < grid.Rows && column >= 0 && grid.GetValue(r, column) == c) {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                    r++;
                    column--;
                }
            }
        }

        return maxCount;
    }

}
