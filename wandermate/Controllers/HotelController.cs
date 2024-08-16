using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wandermate.Data;
using wandermate.DTOs.HotelDTO;
using wandermate.Models;


namespace wandermate.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/hotels")]
    public class HotelController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _context.Hotel.ToListAsync();

            var hotelDTO = hotels.Select(hotel => new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Desc = hotel.Desc,
                Img = hotel.Img,
                Rating = hotel.Rating,
                Price = hotel.Price,
                FreeCancellation = hotel.FreeCancellation,
                ReserveNow = hotel.ReserveNow
            }).ToList();
            return Ok(hotelDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var hotel = await _context.Hotel.Where(h => h.Id == id)
            .Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Desc = h.Desc,
                Img = h.Img,
                Rating = h.Rating,
                Price = h.Price,
                FreeCancellation = h.FreeCancellation,
                ReserveNow = h.ReserveNow
            }).FirstOrDefaultAsync();
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                Desc = hotelDto.Desc,
                Img = hotelDto.Img,
                Price = hotelDto.Price,
                Rating = hotelDto.Rating,
                FreeCancellation = hotelDto.FreeCancellation,
                ReserveNow = hotelDto.ReserveNow
            };
            try
            {
                await _context.Hotel.AddAsync(hotel);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotelDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            // return CreatedAtAction("GetById", new { id = hotel.Id }, hotel);
        }

        //for update the hotel
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO hotelDto)
        {
            var data = await _context.Hotel.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }


            data.Name = hotelDto.Name;
            data.Desc = hotelDto.Desc;
            data.Img = hotelDto.Img;
            data.Price = hotelDto.Price;
            data.Rating = hotelDto.Rating;
            data.FreeCancellation = hotelDto.FreeCancellation;
            data.ReserveNow = hotelDto.ReserveNow;

            _context.Entry(data).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Hotel.Any(h => h.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            try
            {
                _context.Hotel.Remove(hotel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

            return NoContent();
        }
    }
}

