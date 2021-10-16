using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = null;
            do
            {

                Console.WriteLine("Enter one of the following gmaes" +
                    "\nTen" +
                    "\nEleven" +
                    "\nThirteen");
                try
                {
                    game = Game.Create(Console.ReadLine());
                    Console.Clear();
                }
                catch (Exception UserInputException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(UserInputException.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (game == null);

            string[] command;
            while(!(game.HasWon() || game.HasSurrendered))
            {
                game.printBoard();
                command = GetCommand(Console.ReadLine());
                ExecuteCommand(command, game);
                Console.Clear();
            }
        }
        /// <summary>
        /// Excutes the command issued by the player
        /// </summary>
        /// <param name="command">A array that contains the players input</param>
        /// <param name="gameObj">The current game</param>
        private static void ExecuteCommand(string[] command, Game gameObj)
        {
            string token = command[0];
            command = command.Skip(1).ToArray();
            switch (token.ToUpper())
            {
                case Command.SELECT:
                    List<Card> CommandCards = MakeListOfCards(command);
                    gameObj.SelectCard(CommandCards);
                    break;
                case Command.REMOVE:
                    if (gameObj.ConditionToRemove())
                    {
                        gameObj.Remove();
                    }
                    break;
                case Command.REPLACE:
                    gameObj.Replace();
                    break;
                case Command.FORFIET:
                    gameObj.Forfiet();
                    break;
                case Command.HIGHSCORE:
                    throw new NotImplementedException();
                case Command.CHANGENAME:
                    gameObj.ChangeName(command[0]);
                    break;
                default:
                    break;
        
            }
        }
        /// <summary>
        /// creates a list of cards the player wishes to send to game object
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        private static List<Card> MakeListOfCards(string[] vs)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Converts a string input into a array string
        /// </summary>
        /// <param name="input">input to be parse into a string</param>
        /// <returns>returns an array of commands</returns>
        private static string[] GetCommand(string input)
        {
            return input.Split(' ');
        }

    }
    
}

