using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/voteresult")]
    [ApiController]
    public class VoteResultController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VoteResultController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var  voteResult = _context. VoteResult.ToList();

            return Ok( voteResult);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var  voteResult = _context. VoteResult.Find(id);

            if ( voteResult == null)
            {
                return NotFound();
            }

            return Ok( voteResult);
        }
    }
}