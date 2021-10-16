using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    /// <summary>
    /// Command class that contains a list of commands for user
    /// </summary>
    public static class Command
    {
        public const string SELECT = "SELECT";
        public const string REMOVE = "REMOVE";
        public const string REPLACE = "REPLACE";
        public const string FORFIET = "FORFIET";
        public const string HIGHSCORE = "HIGHSCORE";
        public const string CHANGENAME = "CHANGENAME";
    }
}
