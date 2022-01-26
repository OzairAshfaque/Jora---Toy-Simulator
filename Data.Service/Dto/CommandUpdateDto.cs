using Data.Entity.Models;
using Data.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Response
{
   public class CommandUpdateDto
    {
        public string Command { get; set; }
        public ToyRobotDto ToyBehaviourResponse { get; set; }
    }
}
