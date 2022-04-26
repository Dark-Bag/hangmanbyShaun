using System;
using System.Collections.Generic;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        int options;
        List<string> listofWords;
        string word;
        string theWord;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();

            listofWords = new List<string> { "messi", "ronaldo", "neymar", "kevin", "foden", "mbappe", "pele", "maradona", "ederson"};
            Random random = new Random();

            int count = listofWords.Count;

            options = random.Next(0, count);
            word = listofWords[options].ToLower();

        }

        public void Run()
        {
            int incorrectLetter = 0;
            _renderer.Render(5, 5, 5);

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the the player name: ");


            for (int i = 0; i < word.Length; i++)
            {
                theWord += "*";
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(0, 14);
            Console.WriteLine(theWord);

            char nextGuess;


            while (incorrectLetter <= 5)
            {
                char[] displayToPlayer = theWord.ToCharArray();
                Console.SetCursorPosition(0, 16);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Enter the letter: ");

                Console.SetCursorPosition(25, 16);
                nextGuess = char.Parse(Console.ReadLine());

                for (int i = 0; i < word.Length; i++)
                {
                    if (nextGuess == word[i])
                    {
                        displayToPlayer[i] = nextGuess;
                    }
                }

                theWord = new string(displayToPlayer);
                Console.SetCursorPosition(0, 14);
                Console.WriteLine(theWord);
                if (!word.Contains(nextGuess))
                {
                    incorrectLetter++;
                    if (incorrectLetter == 1)
                        _renderer.Render(5, 5, 4);
                    if (incorrectLetter == 2)
                        _renderer.Render(5, 5, 3);
                    if (incorrectLetter == 3)
                        _renderer.Render(5, 5, 2);
                    if (incorrectLetter == 4)
                        _renderer.Render(5, 5, 1);
                    if (incorrectLetter == 5)
                        _renderer.Render(5, 5, 0);

                    if (incorrectLetter == 5)
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Booooooooooooooooom!!!!, the correct player's name is {word}");
                        Console.Write("Press ENTER to exit...");
                        break;
                    }
                }
              
                if (theWord == word)
                {
                    Console.SetCursorPosition(0, 16);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Baaaaaaaaaaaaaaaaaaam!!!!!, You won!!!! the correct name is]: {word} ");
                    Console.Write("Press ENTER to exit...");
                    break;
                }
            }
        }

    }
}