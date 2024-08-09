using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.Data;

namespace wandermate.Controllers
{
    [ApiController]
    [Route("wandermate/hotelReviews")]
    public class HotelReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HotelReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // public IActionResult GetAll(){
        //     return Ok(_context.Review.ToList());
        // }

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Review.ToListAsync());
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var review = _context.Review.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] models.Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }
            _context.Review.Add(review);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = review.ReviewId }, review);
        }
        
}
}