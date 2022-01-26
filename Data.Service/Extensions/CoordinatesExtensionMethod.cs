using Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Extensions
{
    public static class CoordinatesExtensionMethod
    {
        public static bool PositionParameterChecker(this Coordinates positionParameters) 
        {
            if (object.Equals(positionParameters, null))
            {
                return true;
            }

            return false;

        }
    }
}
