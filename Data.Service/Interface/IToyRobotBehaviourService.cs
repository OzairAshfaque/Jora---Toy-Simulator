using Data.Entity.Constant;
using Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Interface
{
    public interface IToyRobotBehaviourService
    {
 


        public Coordinates GetNextCoordinates(Coordinates previousPosition, Directions robotDirection );

        public Directions GetRotation(Directions direction, int rotationalValue);
    }
}
