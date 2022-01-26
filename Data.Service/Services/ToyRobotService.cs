using Data.Entity.Models;
using Data.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Data.Service.Dto;
using Data.Entity.Constant;
using Data.Service.Response;
using Data.Service.Extensions;

namespace Data.Services.Service
{
    public class ToyRobotService : IToyRobotService
    {

        private readonly ICommandParserService _commandParserService;
        public ToyRobotService(ICommandParserService commandParserService) 
        {
            _commandParserService = commandParserService;


        }
        //Initialization of square table with row x columns and sending response to UI

        public ToyRobotResponse Initialization(int rows , int columns)
        {
            var toyRobotModel = new ToyRobotResponse();
            var tableDimension = new Table();
            try 
            {

                tableDimension.Rows = rows;
                tableDimension.Columns = columns;
                tableDimension = tableDimension.SquareTableDimensionChecker();
                toyRobotModel.ToyRobot.TableDimensions = tableDimension;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
            return toyRobotModel;


        }



        public ToyRobotResponse RobotCommand(CommandUpdateResponse inputCommand)
        {

            ToyRobotResponse robotBehaviour = new ToyRobotResponse();

            try
            {
                robotBehaviour = _commandParserService.ProcessCommandQuery(inputCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return robotBehaviour;


        }

    }
}
