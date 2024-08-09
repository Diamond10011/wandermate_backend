using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using wandermate.Data;
using wandermate.DTOS.User;
using wandermate.models;


namespace wandermate.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class SignUpController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        //async
        public async Task<IActionResult> GetAll()
        {
            var userList = await _context.Users.ToListAsync();
            var users = userList.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            }).ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
            }).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (oldUser != null)
            {
                return Conflict("Username already exists");
            }
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var newUser = new Users
            {
                Username = user.Username,
                Email = user.Email,
                Password = hashed
            };

            try
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
        // [HttpPut("id")]
        // public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUser user)
        // {
        //     var data = await _context.Users.FindAsync(id);
        //     if(data == null)
        //     {
        //         return NotFound();
        //     }
        //     data.Username = user.Username;
        //     data.Email = user.Email;
        //     data.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        // }
        

    }
}