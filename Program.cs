namespace MorpionApp
{
    public class Program
    {

        private static char SelectGame() {
            
            char? selection = null;

            while (!selection.HasValue) {
                Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.X || key == ConsoleKey.P) {
                    selection = key.ToString().ToLower()[0];
                } else {
                    Console.WriteLine("Touche invalide. Veuillez taper [X] pour le morpion et [P] pour le puissance 4.");
                }

            }

            return selection.Value;

        }
        
        private static void StartGame(char game) {

            switch (game)
            {
                case 'x':
                    Morpion morpion = new Morpion();
                    morpion.BoucleJeu();
                    break;
                case 'p':
                    PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
                    puissanceQuatre.BoucleJeu();
                    break;
            }

        }

        private static bool PlayAgain() {
                
                Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
    
                var key = Console.ReadKey(true).Key;
    
                if (key == ConsoleKey.R) {
                    return true;
                } else if (key == ConsoleKey.Escape) {
                    return false;
                } else {
                    return PlayAgain();
                }
        }

        static void Main(string[] args)
        {
            do {
                StartGame(SelectGame());
            } while (PlayAgain());
        }

    }
}
