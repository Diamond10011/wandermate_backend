using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wandermate.Data;
using wandermate.Models;

namespace wandermate.Controllers
{
    [ApiController]
    [Route("wandermate/Test")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Test.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var teat = _context.Test.Find(id);
            if (teat == null)
            {
                return NotFound();
            }
            return Ok(teat);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Test teat)
        {
            if (teat == null)
            {
                return BadRequest();
            }
            _context.Test.Add(teat);
            await _context.SaveChangesAsync();
            return StatusCode(201, teat);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Test tp)
        {
            var data = _context.Test.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            data.Id = tp.Id;
            data.Name = tp.Name;
            data.Desc = tp.Desc;
            data.Img = tp.Img;
            data.Price = tp.Price;
            _context.Test.Update(data);
            _context.SaveChanges();
            return Ok(tp);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var teat = _context.Test.Find(id);
            if (teat == null)
            {
                return NotFound();
            }
            _context.Test.Remove(teat);
            _context.SaveChanges();
            return NoContent();
        }
    }
}