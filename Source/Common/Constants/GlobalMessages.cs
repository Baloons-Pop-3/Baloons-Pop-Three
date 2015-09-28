using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Common
{
    public class GlobalMessages
    { 
        public const string ALREADY_POPPED_BALLOON_MSG = "You cannot pop already poppped balloon";
        public const string GREETING_MSG = "Welcome to “Balloons Pops” game. Please try to pop the balloons. Write:\n'start' for starting a new game\n'top' to view the top scoreboard\n'restart' to restart the game\n'exit' to quit the game.\n";
        public const string ROW_COW_MSG = "Enter a row and column: ";
        public const string INVALID_COMMAND_MSG = "Invalid move or command!";
        public const string ADD_TO_TOPSCORE_MSG = "Please enter your name for the top scoreboard: ";

        public const string INVALID_COORDINATES_MSG = "Invalid coordinates! Please try again";
        public const string INVALID_INDEX_OF_FIELD = "There is no such index!";
    }
}
