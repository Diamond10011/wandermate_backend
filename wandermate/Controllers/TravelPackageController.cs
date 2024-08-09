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
    [Route("wandermate/TravelPackages")]
    public class TravelPackageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //constructor
        public TravelPackageController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.TravelPackage.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var travelPackage = _context.TravelPackage.Find(id);
            if (travelPackage == null)
            {
                return NotFound();
            }
            return Ok(travelPackage);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TravelPackage TravelPackage)
        {
            if (TravelPackage == null)
            {
                return BadRequest();
            }
            _context.TravelPackage.Add(TravelPackage);
            _context.SaveChanges();
            // return CreatedAtAction("GetById", new { id = hotel.Id }, hotel);
            return StatusCode(201, TravelPackage);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TravelPackage tp)
        {
            var data = _context.TravelPackage.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            data.Name = tp.Name;
            data.Desc = tp.Desc;
            data.Img = tp.Img;
            data.Price = tp.Price;
            _context.TravelPackage.Update(data);
            _context.SaveChanges();
            return Ok(tp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var tp = _context.TravelPackage.Find(id);
            if (tp == null)
            {
                return NotFound();
            }
            _context.TravelPackage.Remove(tp);
            _context.SaveChanges();
            return NoContent();
        }
    }
}