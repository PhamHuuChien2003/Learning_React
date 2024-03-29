using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/commentcontentvideo")]
    [ApiController]
    public class CommentContentVideoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CommentContentVideoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commentContentVideo = _context.CommentContentVideo.ToList()
                .Select(s => s.ToCommentContentVideoDto());

            return Ok(commentContentVideo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var commentContentVideo = _context.CommentContentVideo.Find(id);

            if (commentContentVideo == null)
            {
                return NotFound();
            }

            return Ok(commentContentVideo.ToCommentContentVideoDto());
        }
    }
}