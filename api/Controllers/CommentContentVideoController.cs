using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentVideo;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var commentContentVideo =await _context.CommentContentVideo.ToListAsync();
            var commentContentVideoDto =commentContentVideo.Select(s => s.ToCommentContentVideoDto());

            return Ok(commentContentVideoDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentContentVideo =await _context.CommentContentVideo.FindAsync(id);

            if (commentContentVideo == null)
            {
                return NotFound();
            }

            return Ok(commentContentVideo.ToCommentContentVideoDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentContentVideoRequestDto createCommentContentVideoDto)
        {
            var commentContentVideoModel = createCommentContentVideoDto.ToCommentContentVideoFromCreateDTO();
            await _context.CommentContentVideo.AddAsync(commentContentVideoModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id=commentContentVideoModel.CommentContentVideoID},commentContentVideoModel.ToCommentContentVideoDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentContentVideoRequestDto updateCommentContentVideoDto)
        {
            var commentContentVideoModel =await _context.CommentContentVideo.FirstOrDefaultAsync(x => x.CommentContentVideoID == id);
            if (commentContentVideoModel == null) 
            {
                return NotFound();
            }
            var commentContentVideoUpdateModel = updateCommentContentVideoDto.ToCommentContentVideoFromUpdateDTO();
            commentContentVideoModel.CommentContent = commentContentVideoUpdateModel.CommentContent;
            commentContentVideoModel.VideoURL = commentContentVideoUpdateModel.VideoURL;
            await _context.SaveChangesAsync();
            return Ok(commentContentVideoModel.ToCommentContentVideoDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentContentVideoModel = _context.CommentContentVideo.FirstOrDefault(x => x.CommentContentVideoID == id);
            if (commentContentVideoModel == null) 
            {
                return NotFound();
            }
            _context.CommentContentVideo.Remove(commentContentVideoModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}