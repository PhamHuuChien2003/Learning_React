using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/commentcontentpic")]
    [ApiController]
    public class CommentContentPicController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CommentContentPicController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commentContentPic = _context.CommentContentPic.ToList()
                .Select(s => s.ToCommentContentPicDto());

            return Ok(commentContentPic);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var commentContentPic = _context.CommentContentPic.Find(id);

            if (commentContentPic == null)
            {
                return NotFound();
            }

            return Ok(commentContentPic.ToCommentContentPicDto());
        }
    }
}