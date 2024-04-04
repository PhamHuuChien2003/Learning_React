using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.User;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user =await _context.User.ToListAsync();
            var userDto = user.Select(s => s.ToUserDto());

            return Ok(userDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user =await _context.User.FindAsync(id);   

            if (user == null)    
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto createUsertDto)
        {
            var userModel = createUsertDto.ToUserFromCreateDTO();
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id = userModel.UserId}, userModel.ToUserDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateUserRequestDto updateUserDto)
        {
            var userModel =await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
            if (userModel == null) 
            {
                return NotFound();
            }
            var userUpdateModel = updateUserDto.ToUserFromUpdateDTO();
            userModel.FirstName = userUpdateModel.FirstName;
            userModel.LastName = userUpdateModel.LastName;
            userModel.Age=userUpdateModel.Age;
            await _context.SaveChangesAsync();
            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var userModel = _context.User.FirstOrDefault(x => x.UserId == id);
            if (userModel == null) 
            {
                return NotFound();
            }
            _context.User.Remove(userModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}