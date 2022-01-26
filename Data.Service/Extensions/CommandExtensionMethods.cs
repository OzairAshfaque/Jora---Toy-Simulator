using Data.Entity.Constant;
using Data.Entity.Models;
using Data.Service.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Extensions
{
    public static class CommandExtensionMethods
    {



        public static Commands CommandQueryParser(this string commandToParse)
        {

            if (!Enum.TryParse(commandToParse, true, out Commands command)) 
            {
                throw new ArgumentException("Sorry, your command was not recognized. Please try again");
            }

            return command;
        }
        public static Directions DirectionParameterParser(this string robotFaceDirection)
        {
           
            if (!Enum.TryParse(robotFaceDirection.ToString(), true, out Directions direction))
            {
                throw new ArgumentException("Sorry, your command was not recognized. Please provide correct directions : NORTH | EAST | SOUTH | WEST");
            }

            return direction;
        }


        public static bool CommandQueryCountChecker(this string[] commandQueryToCheck)
        {
            
            if (commandQueryToCheck.Length != Constants.CommandCount)
            {
                return false;
            }

            return true;
        }
        public static bool ParameterQueryCountChecker(this string[] paramQueryToCheck)
        {
            
            if (paramQueryToCheck.Length != Constants.ParameterCount)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPositionChecker (this Coordinates validPosition, Table tableDimensions) 
        {
            return validPosition.X < tableDimensions.Columns && validPosition.X >= 0 &&
                   validPosition.Y < tableDimensions.Rows && validPosition.Y >= 0;
        }
    }
}
