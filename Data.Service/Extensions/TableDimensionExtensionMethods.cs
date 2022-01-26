using Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Extensions
{
    public static class TableDimensionExtensionMethods
    {
        public static Table SquareTableDimensionChecker(this Table tableDimensions)
        {

            if (object.Equals(tableDimensions, null) || tableDimensions.Columns == 0 || tableDimensions.Rows == 0)
            {
                throw new ArgumentException("Please start app again, table dimensions are missing");
            }
            else if (!tableDimensions.SquareBoardChecker()) 
            {
                throw new ArgumentException("Please start app again, table dimensions are incorrect");
            }

            return tableDimensions;
        }

        public static bool SquareBoardChecker(this Table tableDimensions) 
        {
            if (tableDimensions.Rows != tableDimensions.Columns)
            {
                return false;
            }
            return true;
        }
    }
}
