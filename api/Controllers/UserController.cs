using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.User;
using api.Interfaces;
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
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDBContext context, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user =await _userRepo.GetAllAsync();
            var userDto = user.Select(s => s.ToUserDto());

            return Ok(userDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user =await _userRepo.GetByIdAsync(id);   

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
            await _userRepo.CreateAsync(userModel);
            return CreatedAtAction(nameof(GetById),new { id = userModel.UserId}, userModel.ToUserDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateUserRequestDto updateUserDto)
        {
            var userModel =await _userRepo.UpdateAsync(id,updateUserDto);
            if (userModel == null) 
            {
                return NotFound();
            }
            
            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var userModel = _userRepo.DeleteAsync(id);
            if (userModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}