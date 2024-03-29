using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController  : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var post = _context.Post.ToList()
                .Select(s => s.ToPostDto());

            return Ok(post);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var post = _context.Post.Find(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post.ToPostDto());
        }
    }
}