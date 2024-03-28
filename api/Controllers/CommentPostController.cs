using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/commentpost")]
    [ApiController]
    public class CommentPostController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CommentPostController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commentPost = _context.CommentPost.ToList();

            return Ok(commentPost);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var commentPost = _context.CommentPost.Find(id);

            if (commentPost == null)
            {
                return NotFound();
            }

            return Ok(commentPost);
        }
    }
}