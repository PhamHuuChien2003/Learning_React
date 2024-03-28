using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/postdetailvote")]
    [ApiController]
    public class PostDetailVoteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVoteController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDetailVote = _context.PostDetailVote.ToList();

            return Ok(postDetailVote);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailVote = _context.PostDetailVote.Find(id);

            if (postDetailVote == null)
            {
                return NotFound();
            }

            return Ok(postDetailVote);
        }
    }
}