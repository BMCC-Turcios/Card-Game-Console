using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game;
            Command command = new Command();
            do
            {
                game = null;
                initGame(ref game);
                AskToChangeName(game);
                PlayGame(game, command);
                if (game.HasWon())
                {
                    Console.WriteLine("You have won the game");
                    AskToChangeName(game);
                    game.AddToLeadrBoard();
                    new IOScore(game.GameType).SaveLeaderBoard(game.Leaderboard);
                }
            } while (PlayAgain());
            
        }

        private static void AskToChangeName(Game game)
        {
            string input;
            do
            {
                Console.WriteLine("Current name is " + game.PlayerName);
                Console.WriteLine("Would you like to change your name?" +
                    "\nEnter Y for yes" +
                    "\nEnter N for no");
                input = Console.ReadLine().ToUpper();
                Console.Clear();
            } while (input != "Y" && input != "N");

            if (input == "Y")
            {
                Console.WriteLine("Enter your name");
                game.ChangeName(Console.ReadLine().ToUpper());
            }
        }

        private static bool PlayAgain()
        {
            string input;
            do
            {
                
                Console.WriteLine("would you like to playe again?" +
                    "\nenter Y for yes" +
                    "\nenter N for no");
                input = Console.ReadLine().ToUpper();
                Console.Clear();
            } while (input != "Y" && input != "N");

            return input == "Y";
        }

        private static void PlayGame(Game game, Command command)
        {
            while (!(game.HasWon() || game.HasSurrendered))
            {
                Console.WriteLine("Player name: " + game.PlayerName);
                game.printBoard();
                command.GetCommand(Console.ReadLine().ToUpper());
                command.ExecuteCommand(game);
                Console.Clear();
            }
        }

        private static void initGame(ref Game game)
        {
            do
            {

                Console.WriteLine("Enter one of the following games" +
                    "\nTen" +
                    "\nEleven" +
                    "\nThirteen");
                try
                {
                    game = Game.Create(Console.ReadLine());
                }
                catch (Exception UserInputException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(UserInputException.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (game == null);

            Console.Clear();

        }
    }

}

