using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.UserAccount;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly ITokenService _tokenSevice;
        private readonly SignInManager<UserAccount> _signInManager;
        public AccountController(UserManager<UserAccount> userManager,ITokenService tokenService,SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _tokenSevice = tokenService;
            _signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName == loginDto.UserName.ToLower());
            if(user == null) return Unauthorized("Invalid username!") ;
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if(!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");
            return Ok(
                new NewUserAccountDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenSevice.CreateToken(user)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var userAccount = new UserAccount
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };
                var createdUserAccount = await _userManager.CreateAsync(userAccount,registerDto.Password);

                if(createdUserAccount.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(userAccount, "USER");
                    if(roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserAccountDto{
                                UserName = userAccount.UserName,
                                Email = userAccount.Email,
                                Token = _tokenSevice.CreateToken(userAccount)
                            }
                        );
                    }
                    else 
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUserAccount.Errors);
                }
            } 
            
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }
    }
}