using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.UserAccount;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var userAccount =await _context.UserAccount.ToListAsync();
            var userAccountDto =userAccount.Select(s => s.ToUserAccountDto());

            return Ok(userAccountDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userAccount =await _context.UserAccount.FindAsync(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount.ToUserAccountDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserAccountRequestDto createUserAccountDto)
        {
            var userAccountModel = createUserAccountDto.ToUserAccountFromCreateDTO();
            await _context.UserAccount.AddAsync(userAccountModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= userAccountModel.ID}, userAccountModel.ToUserAccountDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateUserAccountRequestDto updateUserAccountDto)
        {
            var userAccountModel =await _context.UserAccount.FirstOrDefaultAsync(x => x.ID == id);
            if (userAccountModel == null) 
            {
                return NotFound();
            }
            var userAccountUpdateModel = updateUserAccountDto.ToUserAccountFromUpdateDTO();
            userAccountModel.UserName = userAccountUpdateModel.UserName;
            userAccountModel.PassWord= userAccountUpdateModel.PassWord;
            await _context.SaveChangesAsync();
            return Ok(userAccountModel.ToUserAccountDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var userAccountModel = _context.UserAccount.FirstOrDefault(x => x.ID == id);
            if (userAccountModel == null) 
            {
                return NotFound();
            }
            _context.UserAccount.Remove(userAccountModel);
            _context.SaveChanges();
            return NoContent();
        }
    }

}