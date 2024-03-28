using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/votesection")]
    [ApiController]
    public class VotesectionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VotesectionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var  votesection = _context. Votesection.ToList();

            return Ok( votesection);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var  votesection = _context. Votesection.Find(id);

            if ( votesection == null)
            {
                return NotFound();
            }

            return Ok( votesection);
        }
    }
}