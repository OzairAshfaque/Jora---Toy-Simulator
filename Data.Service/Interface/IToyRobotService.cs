using Data.Entity.Models;
using Data.Service.Response;
using Data.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service.Interface
{
    public interface IToyRobotService
    {
        public ToyRobotResponse Initialization(int row, int column);
        public CommandRobotResponse RobotResponse(CommandRobotResponse commandDto);
        public ToyRobotResponse RobotCommand(CommandUpdateResponse inputCommand);
        public string ToyRobotReport(CommandUpdateResponse report);
    }
}
