using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/reactpost")]
    [ApiController]
    public class ReactPostController  : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ReactPostController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reactPost = _context.ReactPost.ToList()
                .Select(s => s.ToReactPostDto());

            return Ok(reactPost);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var reactPost = _context.ReactPost.Find(id);

            if (reactPost == null)
            {
                return NotFound();
            }

            return Ok(reactPost.ToReactPostDto());
        }
    }
}