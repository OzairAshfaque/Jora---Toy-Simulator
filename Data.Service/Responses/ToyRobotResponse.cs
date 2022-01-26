using Data.Service.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Dto
{
    public class ToyRobotResponse
    {
        public ToyRobotDto ToyRobot { get; set; }
        public ToyRobotResponse()
        {
            ToyRobot = new ToyRobotDto();
        }



    }
}
