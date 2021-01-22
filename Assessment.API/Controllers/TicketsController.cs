using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.BL.Interfaces;
using Assessment.Shared.Models;
using Assessment.DL.Entities;

namespace Assessment.API.Controllers
{
    [ApiController]//Important for body binding
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly Logger _logger;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        [HttpGet]
        public ActionResult<List<GetInTouchDTO>> GetTickets()
        {
            try
            {
                var results = _ticketService.GetAllTickets();
                return Ok(results);
            }
            catch (Exception ex)
            {

                _logger.Error($"{ex.InnerException}:ActionResult<List<TicketDTO>> GetTickets()");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }
        }
        
        [HttpGet("{ticketId}")]
        public ActionResult<TicketDTO> GetTicketById(int ticketId)
        {
            try
            {
                var result = _ticketService.GetTicketById(ticketId);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }
        }

        [HttpGet("{userId}/{loggedIn}")]
        public ActionResult<List<TicketDTO>> GetTicketByUserId(string userId, bool loggedIn)
        {
            try
            {
                var result = _ticketService.GetTicketByUserId(userId);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }
        }

        [HttpPost]
        [Route("Save")]
        public ActionResult PostTicket([FromBody]GetInTouchDTO ticket)
        {
            try
            {
                var result = _ticketService.AddNewTicket(ticket);

                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }
            return BadRequest("Could not find the ticket");
        }

     
        public ActionResult PostClient(TicketDTO ticket)
        {
            //try
            //{
            //    var result = _ticketService.AddNewTicket(ticket);
            //    if (result != null)
            //    {
            //        return Created($"/api/tickets/{result.TicketId}", result);
            //    }
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            //}
            return BadRequest("Could not find the ticket");
        }

        [HttpPut("{ticketId}")]
        public ActionResult<TicketDTO> Put(int ticketId, TicketDTO ticket )
        {
            try
            {
                var oldTicket = _ticketService.GetTicketById(ticketId);
                if (oldTicket == null) return BadRequest($"Could not find ticket #{ticketId}");

                if (_ticketService.UpdateTicket(ticketId, ticket) != null) return _ticketService.UpdateTicket(ticketId, ticket);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }
            return BadRequest();
        }

        [HttpDelete("{userId}/{ticketId}")]
        public ActionResult<List<TicketDTO>> DeleteById(string userId, int ticketId)
        {
            try
            {
                var result = _ticketService.DeleteTicketById(userId, ticketId);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }

        }
    }
}
