﻿using System;
using System.Collections.Generic;

namespace MorpionApp
{
    public class Morpion
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public Grid<char> grille;

        public Morpion()
        {
            grille = new Grid<char>(3, 3);
            grille.SetGrid(new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            });
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {

                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        tourJoueur();
                        if (verifVictoire('X'))
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur2();
                        if (verifVictoire('O'))
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
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
                affichePlateau();
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
                        if (column >= 2)
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
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille.GetValue(row, column) is ' ')
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
                affichePlateau();
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
                        if (column >= 2)
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
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille.GetValue(row, column) is ' ')
                        {
                            grille.SetValue(row, column, 'O');
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }
            }
        }

        public void affichePlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille.GetValue(0, 0)}  |  {grille.GetValue(0, 1)}  |  {grille.GetValue(0, 2)}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille.GetValue(1, 0)} |  {grille.GetValue(1, 1)}  |  {grille.GetValue(1, 2)}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grille.GetValue(2, 0)}  |  {grille.GetValue(1, 1)}  |  {grille.GetValue(0, 2)}");
        }

        public bool verifVictoire(char c) =>
             grille.GetValue(0, 0) == c && grille.GetValue(1, 0) == c && grille.GetValue(2, 0) == c ||
             grille.GetValue(0, 1) == c && grille.GetValue(1, 1) == c && grille.GetValue(2, 1) == c ||
             grille.GetValue(0, 2) == c && grille.GetValue(1, 2) == c && grille.GetValue(2, 2) == c ||
             grille.GetValue(0, 0) == c && grille.GetValue(1, 1) == c && grille.GetValue(2, 2) == c ||
             grille.GetValue(1, 0) == c && grille.GetValue(1, 1) == c && grille.GetValue(1, 2) == c ||
             grille.GetValue(2, 0) == c && grille.GetValue(2, 1) == c && grille.GetValue(2, 2) == c ||
             grille.GetValue(0, 0) == c && grille.GetValue(1, 1) == c && grille.GetValue(2, 2) == c ||
             grille.GetValue(2, 0) == c && grille.GetValue(1, 1) == c && grille.GetValue(0, 2) == c;

        public bool verifEgalite() =>
            grille.GetValue(0, 0) != ' ' && grille.GetValue(1, 0) != ' ' && grille.GetValue(2, 0) != ' ' &&
            grille.GetValue(0, 1) != ' ' && grille.GetValue(1, 1) != ' ' && grille.GetValue(2, 1) != ' ' &&
            grille.GetValue(0, 2) != ' ' && grille.GetValue(1, 2) != ' ' && grille.GetValue(2, 2) != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
