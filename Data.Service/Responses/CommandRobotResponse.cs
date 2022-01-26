using Data.Entity.Constant;
using Data.Entity.Models;
using Data.Service.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Dto
{
    public class CommandRobotResponse
    {
        public ToyRobotDto RobotResponse { get; set; }
        public CommandRobotResponse()
        {
            RobotResponse = new ToyRobotDto();
        }



    }
}
