using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WorldLeagueAPI.Models;
using WorldLeagueAPI.Models.Request;
using WorldLeagueAPI.Models.Response;
using WorldLeagueAPI.Services.Abstract;

namespace WorldLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrawController : ControllerBase
    {
        private readonly IDrawService _drawService;

        public DrawController(IDrawService drawService)
        {
            _drawService = drawService;
        }

        [HttpPost("RunDraw")]
        public IActionResult RunDraw([FromBody] DrawRequest request)
        {
            try
            {
                var groups = _drawService.RunDraw(request.GroupCount,request.FirstName,request.LastName);
                var response = new DrawResponse
                {
                    Groups = groups
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

}
