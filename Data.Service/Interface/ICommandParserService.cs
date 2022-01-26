using Data.Service.Response;
using Data.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Interface
{
    public interface ICommandParserService
    {
        public ToyRobotResponse ProcessCommandQuery( CommandUpdateResponse inputCommand);
    }
}
