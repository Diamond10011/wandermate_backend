using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wandermate.Data;
using wandermate.models;

namespace wandermate.Controllers
{
    [ApiController]
    [Route("wandermate/Destination")]
    public class DestinationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //constructor
        public DestinationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Destination.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var destination = _context.Destination.Find(id);
            if (destination == null)
            {
                return NotFound();
            }
            return Ok(destination);
        }

        [HttpPost]
        public IActionResult AddDestination([FromBody] Destination destination)
        {
            if (destination == null)
            {
                return BadRequest();
            }
            _context.Destination.Add(destination);
            _context.SaveChanges();
            return StatusCode(201, destination);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDestination([FromRoute] int id, [FromBody] models.Destination destination)
        {
            var data = _context.Destination.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            data.Title = destination.Title;
            data.Desc = destination.Desc;
            data.Img = destination.Img;
            data.Weather = destination.Weather;
            _context.Destination.Update(data);
            _context.SaveChanges();
            return Ok(destination);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDestination([FromRoute] int id)
        {
            var destination = _context.Destination.Find(id);
            if (destination == null)
            {
                return NotFound();
            }
            _context.Destination.Remove(destination);
            _context.SaveChanges();
            return NoContent();
        }
    }
}