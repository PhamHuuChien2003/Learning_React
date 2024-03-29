using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/postdetailsgpicwithcaption")]
    [ApiController]
    public class PostDetailSGPicWithCaptionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailSGPicWithCaptionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDetailSGPicWithCaption = _context.PostDetailSGPicWithCaption.ToList()
                .Select(s => s.ToPostDetailSGPicWithCaptionDto());

            return Ok(postDetailSGPicWithCaption);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailSGPicWithCaption = _context.PostDetailSGPicWithCaption.Find(id);

            if (postDetailSGPicWithCaption == null)
            {
                return NotFound();
            }

            return Ok(postDetailSGPicWithCaption.ToPostDetailSGPicWithCaptionDto());
        }
    }
}