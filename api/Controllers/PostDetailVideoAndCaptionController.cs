using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/postdetailvideoandcaption")]
    [ApiController]
    public class PostDetailVideoAndCaptionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVideoAndCaptionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDetailVideoAndCaption = _context.PostDetailVideoAndCaption.ToList()
                .Select(s => s.ToPostDetailVideoAndCaptionDto());

            return Ok(postDetailVideoAndCaption);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailVideoAndCaption = _context.PostDetailVideoAndCaption.Find(id);

            if (postDetailVideoAndCaption == null)
            {
                return NotFound();
            }

            return Ok(postDetailVideoAndCaption.ToPostDetailVideoAndCaptionDto());
        }
    }
}