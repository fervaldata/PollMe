using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollMe.Business.Services;
using PollMe.Business.Services.DTO;

namespace PollMe.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class PollController : ControllerBase
    {
        private readonly IPollService _MainService;

        public PollController(IPollService service)
        {
            this._MainService = service;
        }



       
        [HttpGet]
        public ActionResult Get([FromQuery] int id)
        {
            return Ok(_MainService.Get(id));
        }

        [HttpPost]
        public ActionResult CreatePoll([FromBody] PollDTO Poll)
        {
            try
            {
                _MainService.CreatePoll(Poll);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult CreateEvent([FromBody] EventDTO Event)
        {
            try
            {
                _MainService.CreateEvent(Event);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Vote([FromQuery] int id)
        {
            try
            {
                _MainService.Vote(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteEvent([FromQuery] int id)
        {
            try
            {
                _MainService.DeleteEvent(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeletePoll([FromQuery] int id)
        {
            try
            {
                _MainService.DeletePoll(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}
