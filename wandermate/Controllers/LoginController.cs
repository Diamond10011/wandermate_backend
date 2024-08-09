using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using wandermate.DTOS.User;
using wandermate.Data;
using wandermate.models;
using BCrypt.Net;
namespace wandermate.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        /* [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        } */
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var request = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginDto.Username);
            if (request == null)
            {
                return BadRequest("User does not exist");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, request.Password);
            if (!isPasswordValid)
            {
                return Unauthorized("Incorrect Password");
            }
            return Ok(loginDto);
        }

    }
}