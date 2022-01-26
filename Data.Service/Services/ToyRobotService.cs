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

        public CommandRobotResponse RobotResponse(CommandRobotResponse commandDto)
        {
            var toyRobotModel = new CommandRobotResponse();

            var tableDimension = new Table();
            var cmd = new CommandModel();
            var position = new Coordinates();
            var fDirection = new FaceDirection();

            try
            {
                tableDimension.Rows = 5;
                tableDimension.Columns = 5;
                cmd.Command = Commands.PLACE;

                position.X = 2;
                position.Y = 3;
                fDirection.Direction = Directions.EAST;

                toyRobotModel.RobotResponse.TableDimensions = tableDimension;
                //toyRobotModel.RobotResponse.ExecutedCommand = cmd;
                toyRobotModel.RobotResponse.Position = position;
                toyRobotModel.RobotResponse.RoboFaceDirection = fDirection;



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return toyRobotModel;


        }

        public ToyRobotResponse RobotCommand(CommandUpdateResponse inputCommand)
        {

            ToyRobotResponse robotBehaviour = new ToyRobotResponse();
            //CommandResponseDto cm = new CommandResponseDto();
            //var tableDimension = new Table();
            //var position = new Coordinates();
            //var fDirection = new FaceDirection();


            try
            {
               // //tableDimension.Rows = 5;
               // //tableDimension.Columns = 5;
               // string commd = "place 1,1,NORTH";
               // //position.X = 2;
               //// position.Y = 3;
               // //fDirection.Direction = Directions.EAST;


               // command.ComandToExecute.Command = commd;

               // cm.RobotResponse.TableDimensions = tableDimension;
               // cm.RobotResponse.Position = position;
               // cm.RobotResponse.RoboFaceDirection = fDirection;

               // command.ComandToExecute.Response = cm.RobotResponse;





                robotBehaviour = _commandParserService.ProcessCommandQuery(inputCommand);
                //tableDimension = commandUpdateDto.ComandToExecute.TableDimensions;



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return robotBehaviour;


        }

        public string ToyRobotReport(CommandUpdateResponse report)
        {

            return "Output: " + report.ComandToExecute.ToyBehaviourResponse.Position.X + "," +
                report.ComandToExecute.ToyBehaviourResponse.Position.Y + "," +
                report.ComandToExecute.ToyBehaviourResponse.RoboFaceDirection;
        }
    }
}
