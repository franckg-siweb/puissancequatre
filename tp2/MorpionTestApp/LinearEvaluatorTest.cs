namespace MorpionTestApp
{
    public class LinearEvaluatorTest
    {
        [Fact]
        public void LonguestLine_HorizontalLine_ReturnsCorrectCount()
        {
            // Arrange
            Grid<char> grid = new Grid<char>(3, 3);
            grid.SetValue(0, 0, 'X');
            grid.SetValue(0, 1, 'X');
            grid.SetValue(0, 2, 'X');

            // Act
            int result = LinearEvaluator.LonguestLine(grid, 'X');

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void LonguestLine_VerticalLine_ReturnsCorrectCount()
        {
            // Arrange
            Grid<char> grid = new Grid<char>(3, 3);
            grid.SetValue(0, 0, 'O');
            grid.SetValue(1, 0, 'O');
            grid.SetValue(2, 0, 'O');

            // Act
            int result = LinearEvaluator.LonguestLine(grid, 'O');

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void LonguestLine_DiagonalLine_ReturnsCorrectCount()
        {
            // Arrange
            Grid<char> grid = new Grid<char>(3, 3);
            grid.SetValue(0, 0, 'X');
            grid.SetValue(1, 1, 'X');
            grid.SetValue(2, 2, 'X');

            // Act
            int result = LinearEvaluator.LonguestLine(grid, 'X');

            // Assert
            Assert.Equal(3, result);
        }
    }
}
