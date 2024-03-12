using MorpionApp;

namespace MorpionTestApp
{
    public class MorpionTest
    {
        [Fact]
        public void VerifVictoire_ReturnsTrue_WhenVictoryConditionIsMet()
        {
            var morpion = new Morpion();
            morpion.grille.SetGrid(new char[,]
            {
                { 'X', ' ', ' ' },
                { 'X', 'X', ' ' },
                { 'X', ' ', 'X' }
            });

            Assert.True(morpion.verifVictoire('X'));
        }

        [Fact]
        public void VerifVictoire_ReturnsFalse_WhenVictoryConditionIsNotMet()
        {
            var morpion = new Morpion();
            morpion.grille.SetGrid(new char[,] {
                { 'X', ' ', ' ' },
                { 'O', 'O', ' ' },
                { 'X', ' ', 'X' }
            });
            Assert.False(morpion.verifVictoire('X'));
        }

        [Fact]
        public void VerifEgalite_ReturnsTrue_WhenAllCellsAreFilled()
        {
            var morpion = new Morpion();
            morpion.grille.SetGrid( new char[,]
            {
                { 'X', 'O', 'X' },
                { 'O', 'X', 'O' },
                { 'O', 'X', 'O' }
            });

            Assert.True(morpion.verifEgalite());
        }

        [Fact]
        public void VerifEgalite_ReturnsFalse_WhenNotAllCellsAreFilled()
        {
            var morpion = new Morpion();
            morpion.grille.SetGrid(new char[,]
            {
                { 'X', 'O', 'X' },
                { 'O', 'X', ' ' },
                { 'O', 'X', 'O' }
            });

            Assert.False(morpion.verifEgalite());
        }
    }

}


