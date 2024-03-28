using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
            var userAccount = _context.UserAccount.ToList();

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

            return Ok(userAccount);
        }

    }

}