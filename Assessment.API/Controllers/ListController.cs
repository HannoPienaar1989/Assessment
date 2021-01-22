using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.BL.Interfaces;
using Assessment.Shared.Models;

namespace Assessment.API.Controllers
{
    [ApiController]//Important for body binding
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet("{type}")]
        public ActionResult<List<ListDTO>> Get(string type)
        {
            try
            {
                var results = _listService.GetListByName(type);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong, please contact administrator");
            }

        }
    }
}
