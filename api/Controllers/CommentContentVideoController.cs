using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentVideo;
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
        [HttpPost]
        public IActionResult Create([FromBody] CreateCommentContentVideoRequestDto createCommentContentVideoDto)
        {
            var commentContentVideoModel = createCommentContentVideoDto.ToCommentContentVideoFromCreateDTO();
            _context.CommentContentVideo.Add(commentContentVideoModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id=commentContentVideoModel.CommentContentVideoID},commentContentVideoModel.ToCommentContentVideoDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateCommentContentVideoRequestDto updateCommentContentVideoDto)
        {
            var commentContentVideoModel = _context.CommentContentVideo.FirstOrDefault(x => x.CommentContentVideoID == id);
            if (commentContentVideoModel == null) 
            {
                return NotFound();
            }
            commentContentVideoModel = updateCommentContentVideoDto.ToCommentContentVideoFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= commentContentVideoModel.CommentContentVideoID}, commentContentVideoModel.ToCommentContentVideoDto());
        }
    }
}