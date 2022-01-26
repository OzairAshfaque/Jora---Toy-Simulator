using Data.Entity.Constant;
using Data.Entity.Models;
using Data.Service.Response;
using Data.Service.Extensions;
using Data.Service.Interface;
using Data.Service.Dto;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Services
{
    public class CommandParserService : ICommandParserService
    {
        private readonly IToyRobotBehaviourService _toyRobotBehaviourService;

        public CommandParserService(IToyRobotBehaviourService toyRobotBehaviourService)
        {
            _toyRobotBehaviourService = toyRobotBehaviourService;
        }

        public ToyRobotResponse ProcessCommandQuery(CommandUpdateResponse inputCommand)
        {
            var commandQuery = inputCommand.ComandToExecute.Command.Split(' ');
            ToyRobotResponse robotDto = new ToyRobotResponse();
            FaceDirection faceDirection = new FaceDirection();
            Coordinates robotPosition = new Coordinates();

            try 
            {
                var tableDimensions = inputCommand.ComandToExecute.ToyBehaviourResponse.TableDimensions.SquareTableDimensionChecker();
                var command = commandQuery[0].CommandQueryParser();
                if (command != Commands.PLACE && inputCommand.ComandToExecute.ToyBehaviourResponse.Position == null ||
                    command != Commands.PLACE && inputCommand.ComandToExecute.ToyBehaviourResponse.RoboFaceDirection == null)
                {
                    throw new ArgumentException("Incorrect Command - Please follow the format: PLACE X,Y,F");
                }
                else 
                {
                    switch (command)
                    {
                        case Commands.PLACE:
                            if (commandQuery.CommandQueryCountChecker())
                            {
                                var robotParameters = commandQuery[1].Split(',');
                                if (robotParameters.ParameterQueryCountChecker())
                                {


                                    faceDirection.Direction = robotParameters[2].DirectionParameterParser();

                                        robotPosition.X = Int32.Parse(robotParameters[0]);
                                        robotPosition.Y = Int32.Parse(robotParameters[1]);
                                        //Redundant
                                        //var positionUpdate = _toyRobotBehaviourService.RobotPlacement(robotPosition, initialFaceDirection);

                                        robotDto.ToyRobot.TableDimensions = tableDimensions;
                                        robotDto.ToyRobot.Position = robotPosition;
                                        robotDto.ToyRobot.RoboFaceDirection = faceDirection;

                                }
                                else
                                {
                                    throw new ArgumentException("Incorrect Command - Please follow the format: PLACE X,Y,F");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Incorrect Command - Please follow the format: PLACE X,Y,F");
                            }
                            break;
                        case Commands.MOVE:
                            //Getting direction of ToyRobot from enum Directions
                            var direction = inputCommand.ComandToExecute.ToyBehaviourResponse.RoboFaceDirection.Direction.ToString().DirectionParameterParser();
                            faceDirection.Direction = direction;

                            robotPosition = _toyRobotBehaviourService.GetNextCoordinates(inputCommand.ComandToExecute.ToyBehaviourResponse.Position, direction);
                            if (robotPosition.IsValidPositionChecker(tableDimensions))
                            {
                                robotDto.ToyRobot.TableDimensions = tableDimensions;
                                robotDto.ToyRobot.Position = robotPosition;
                                robotDto.ToyRobot.RoboFaceDirection = faceDirection;


                            }
                            else
                            {
                                throw new ArgumentException($"ToyRobot cannot move further in { faceDirection.Direction }, as no more space left on table.");
                            }
                            break;
                        //Anticlock-wise Rotation
                        case Commands.LEFT:
                            direction = inputCommand.ComandToExecute.ToyBehaviourResponse.RoboFaceDirection.Direction.ToString().DirectionParameterParser();
                            faceDirection.Direction = _toyRobotBehaviourService.GetRotation(direction, Constants.rotatationLeftValue);

                            robotDto.ToyRobot.TableDimensions = tableDimensions;
                            robotDto.ToyRobot.Position = inputCommand.ComandToExecute.ToyBehaviourResponse.Position;
                            robotDto.ToyRobot.RoboFaceDirection = faceDirection;

                            break;
                        case Commands.RIGHT:
                            direction = inputCommand.ComandToExecute.ToyBehaviourResponse.RoboFaceDirection.Direction.ToString().DirectionParameterParser();
                            faceDirection.Direction = _toyRobotBehaviourService.GetRotation(direction, Constants.rotationRightValue);

                            robotDto.ToyRobot.TableDimensions = tableDimensions;
                            robotDto.ToyRobot.Position = inputCommand.ComandToExecute.ToyBehaviourResponse.Position;
                            robotDto.ToyRobot.RoboFaceDirection = faceDirection;

                            break;
                        case Commands.REPORT:
                            faceDirection.Direction = inputCommand.ComandToExecute.ToyBehaviourResponse.RoboFaceDirection.Direction;
                            robotDto.ToyRobot.Position = inputCommand.ComandToExecute.ToyBehaviourResponse.Position;                        
                            robotDto.ToyRobot.RoboFaceDirection = faceDirection;
                            robotDto.ToyRobot.Report = "Output: "+ robotDto.ToyRobot.Position.X +","+ robotDto.ToyRobot.Position.Y+","+ faceDirection.Direction;
                            break;
                    }
                }

                
               

            } catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return robotDto;

        }
    }
}
