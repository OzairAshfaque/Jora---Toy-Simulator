using Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Response

{
    public class ToyRobotDto
    {
        public Table TableDimensions { get; set; }
        public Coordinates Position { get; set; }
        public FaceDirection RoboFaceDirection { get; set; }
        public string Report { get; set; }


    }
}
