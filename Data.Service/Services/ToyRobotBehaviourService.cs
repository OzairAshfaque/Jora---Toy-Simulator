using Data.Entity.Constant;
using Data.Entity.Models;
using Data.Service.Extensions;
using Data.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Services
{
    public class ToyRobotBehaviourService : IToyRobotBehaviourService
    {
        public Coordinates GetNextCoordinates(Coordinates previousPosition, Directions faceDirection)
        {
            Coordinates newPosition = new Coordinates();
            switch (faceDirection) 
            {
                case Directions.EAST:
                    newPosition.X = previousPosition.X + 1;
                    newPosition.Y = previousPosition.Y;
                    break;
                case Directions.WEST:
                    newPosition.X = previousPosition.X - 1;
                    newPosition.Y = previousPosition.Y;
                    break;
                case Directions.NORTH:
                    newPosition.X = previousPosition.X;
                    newPosition.Y = previousPosition.Y + 1;
                    break;
                case Directions.SOUTH:
                    newPosition.X = previousPosition.X ;
                    newPosition.Y = previousPosition.Y - 1;
                    break;
            }
            return newPosition;
        }

        public Directions GetRotation(Directions direction, int rotationalValue)
        {
            return direction.Rotation(rotationalValue);
        }


    }
}
