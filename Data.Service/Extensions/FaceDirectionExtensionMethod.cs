using Data.Entity.Constant;
using Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Extensions
{
    public static class FaceDirectionExtensionMethod
    {
        public static Directions Rotation(this Directions previousFaceDirection, int rotationalValue)
        {
            var directionArray = (Directions[] )Enum.GetValues(typeof(Directions));
            Directions newFaceDirection;
            if ((int)(previousFaceDirection + rotationalValue)  < Constants.MinDirectionValue) 
            {
                 newFaceDirection = directionArray[directionArray.Length - 1];
            }
            else 
            {
                var currentIndexValue = Array.IndexOf(directionArray, previousFaceDirection);
                var newIndexValue = (currentIndexValue + rotationalValue) % directionArray.Length;
                newFaceDirection = directionArray[newIndexValue];
            }

            return newFaceDirection;
        }
    }
}
