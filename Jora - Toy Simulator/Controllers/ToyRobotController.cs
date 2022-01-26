using Data.Service.Response;
using Data.Service.Interface;
using Data.Service.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Jora___Toy_Simulator.Controllers
{

    public class ToyRobotController : BaseApiController
    {
        private readonly IToyRobotService _toyRobotService;
       public ToyRobotController(IToyRobotService toyRobotServic) 
        {
            _toyRobotService = toyRobotServic;
        }


        [HttpGet]
        [ActionName("initialization")]
        public ActionResult<ToyRobotResponse> Initialization()
        {
            ToyRobotResponse response = new ToyRobotResponse();
            try
            {
                response = _toyRobotService.Initialization(5, 5);
            //    HttpContext.Session.SetString("ToyRobotData", JsonSerializer.Serialize(response.ToyRobot));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonSerializer.Serialize(response.ToyRobot.TableDimensions)); ;

        }


        [HttpPost]
        [ActionName("commandupdate")]
        public ActionResult<ToyRobotResponse> RobotCommandUpdate([FromBody]CommandUpdateResponse inputCommand)
        {
            ToyRobotResponse response = new ToyRobotResponse();
            try
            {
                //if (HttpContext.Session.GetString("ToyRobotData") != null)
                //{
                 //   var sessionData = JsonSerializer.Deserialize<ToyRobotDto>(HttpContext.Session.GetString("ToyRobotData"));
                  //  inputCommand.ComandToExecute.ToyBehaviourResponse = sessionData;
                    response = _toyRobotService.RobotCommand(inputCommand);
                   // HttpContext.Session.SetString("ToyRobotData", JsonSerializer.Serialize(response.ToyRobot));
               // }
                //else 
                //{
                //    throw new ArgumentException("Incorrect Command - Please use Place command f");
                //}



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(JsonSerializer.Serialize(response));

        }


    }
}
