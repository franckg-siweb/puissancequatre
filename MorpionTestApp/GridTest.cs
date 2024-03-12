using MorpionApp;

namespace MorpionTestApp
{
    public class GridTest
    {
        [Fact]
        public void GetValue_ReturnsCorrectValue()
        {
            // Arrange
            Grid<int> grid = new Grid<int>(3, 3);
            grid.SetValue(1, 1, 5);

            // Act
            int value = grid.GetValue(1, 1);

            // Assert
            Assert.Equal(5, value);
        }

        [Fact]
        public void SetValue_SetsCorrectValue()
        {
            // Arrange
            Grid<string> grid = new Grid<string>(2, 2);

            // Act
            grid.SetValue(0, 1, "X");

            // Assert
            Assert.Equal("X", grid.GetValue(0, 1));
        }

        [Fact]
        public void SetGrid_SetsCorrectGrid()
        {
            // Arrange
            Grid<char> grid = new Grid<char>(2, 2);
            char[,] newGrid = new char[,]
            {
                { 'O', 'X' },
                { 'X', 'O' }
            };

            // Act
            grid.SetGrid(newGrid);

            // Assert
            Assert.Equal('O', grid.GetValue(0, 0));
            Assert.Equal('X', grid.GetValue(0, 1));
            Assert.Equal('X', grid.GetValue(1, 0));
            Assert.Equal('O', grid.GetValue(1, 1));
        }

        [Fact]
        public void IsFree_ReturnsTrueForEmptyCell()
        {
            // Arrange
            Grid<string> grid = new Grid<string>(2, 2);

            // Act
            bool isFree = grid.IsFree(0, 0);

            // Assert
            Assert.True(isFree);
        }

        [Fact]
        public void IsFree_ReturnsFalseForOccupiedCell()
        {
            // Arrange
            Grid<int> grid = new Grid<int>(2, 2);
            grid.SetValue(1, 1, 5);

            // Act
            bool isFree = grid.IsFree(1, 1);

            // Assert
            Assert.False(isFree);
        }

        [Fact]
        public void IsFull_ReturnsTrueForFullGrid()
        {
            // Arrange
            Grid<string> grid = new Grid<string>(2, 2);
            grid.SetValue(0, 0, "X");
            grid.SetValue(0, 1, "O");
            grid.SetValue(1, 0, "O");
            grid.SetValue(1, 1, "X");

            // Act
            bool isFull = grid.IsFull();

            // Assert
            Assert.True(isFull);
        }

        [Fact]
        public void IsFull_ReturnsFalseForEmptyGrid()
        {
            // Arrange
            Grid<int> grid = new Grid<int>(2, 2);

            // Act
            bool isFull = grid.IsFull();

            // Assert
            Assert.False(isFull);
        }
    }
}
