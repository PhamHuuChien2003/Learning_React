using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.User;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var user = _context.User.ToList()
                .Select(s => s.ToUserDto());

            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.User.Find(id);   

            if (user == null)    
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }
        [HttpPost]

        public IActionResult Create([FromBody] CreateUserRequestDto createUsertDto)
        {
            var userModel = createUsertDto.ToUserFromCreateDTO();
            _context.User.Add(userModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id = userModel.UserId}, userModel.ToUserDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateUserRequestDto updateUserDto)
        {
            var userModel = _context.User.FirstOrDefault(x => x.UserId == id);
            if (userModel == null) 
            {
                return NotFound();
            }
            userModel = updateUserDto.ToUserFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= userModel.UserId}, userModel.ToUserDto());
        }

    }
}