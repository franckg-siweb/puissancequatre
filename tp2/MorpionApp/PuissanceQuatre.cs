namespace MorpionApp
{
    public class PuissanceQuatre
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public Grid<char> grille = new Grid<char>(4, 7);
        private readonly int lineToWin = 4;

        public PuissanceQuatre()
        {}

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        tourJoueur();
                        if (LinearEvaluator.LonguestLine(grille, 'X') >= lineToWin)
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur2();
                        if (LinearEvaluator.LonguestLine(grille, 'O') >= lineToWin)
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (grille.IsFull())
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
                            Console.Clear();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        public void tourJoueur()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                grille.Print();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 6)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 6;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.Enter:
                        while (row <= 3)
                        {
                            row = row + 1;
                            if (row >= 3)
                            {
                                break;
                            }
                        }
                        while (grille.GetValue(row, column) is 'X' or 'O')
                        {
                            if (row == 0)
                            {
                                break;
                            }

                            row = row - 1;
                        }
                        if(grille.IsFree(row, column))
                        {
                            grille.SetValue(row, column, 'X');
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }

            }
        }

        public void tourJoueur2()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                grille.Print();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
                Console.SetCursorPosition(column * 2, row * 2);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 6)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 6;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        while (row <= 3)
                        {
                            row = row + 1;
                            if (row >= 3)
                            {
                                break;
                            }
                        }
                        while (grille.GetValue(row, column) is 'X' or 'O')
                        {
                            if(row == 0)
                            {
                                break;
                            }

                            row = row - 1;
                        }
                        if (grille.IsFree(row, column))
                        {
                            grille.SetValue(row, column, 'O');
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }
            }
        }


        public void finPartie(string msg)
        {
            Console.Clear();
            grille.Print();
            Console.WriteLine(msg);
        }
    }
}
