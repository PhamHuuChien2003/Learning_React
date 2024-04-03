using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.UserAccount;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/useraccount")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserAccountController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userAccount = _context.UserAccount.ToList()
                .Select(s => s.ToUserAccountDto());

            return Ok(userAccount);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var userAccount = _context.UserAccount.Find(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount.ToUserAccountDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserAccountRequestDto createUserAccountDto)
        {
            var userAccountModel = createUserAccountDto.ToUserAccountFromCreateDTO();
            _context.UserAccount.Add(userAccountModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= userAccountModel.ID}, userAccountModel.ToUserAccountDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateUserAccountRequestDto updateUserAccountDto)
        {
            var userAccountModel = _context.UserAccount.FirstOrDefault(x => x.ID == id);
            if (userAccountModel == null) 
            {
                return NotFound();
            }
            userAccountModel = updateUserAccountDto.ToUserAccountFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= userAccountModel.ID}, userAccountModel.ToUserAccountDto());
        }

    }

}