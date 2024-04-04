using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentPic;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var commentContentPic =await _context.CommentContentPic.ToListAsync();
            var commentContentPicDto = commentContentPic.Select(s => s.ToCommentContentPicDto());

            return Ok(commentContentPicDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentContentPic =await _context.CommentContentPic.FindAsync(id);

            if (commentContentPic == null)
            {
                return NotFound();
            }

            return Ok(commentContentPic.ToCommentContentPicDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentContentPicRequestDto createCommentContentPicDto)
        {
            var commentContentPicModel = createCommentContentPicDto.ToCommentContentPicFromCreateDTO();
            await _context.CommentContentPic.AddAsync(commentContentPicModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= commentContentPicModel.CommentContentPicID}, commentContentPicModel.ToCommentContentPicDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentContentPicRequestDto updateCommentContentPicDto)
        {
            var commentContentPicModel =await _context.CommentContentPic.FirstOrDefaultAsync(x => x.CommentContentPicID == id);
            if (commentContentPicModel == null) 
            {
                return NotFound();
            }
            var commentContentPicUpdateModel = updateCommentContentPicDto.ToCommentContentPicFromUpdateDTO();
            commentContentPicModel.CommentContent = commentContentPicUpdateModel.CommentContent;
            commentContentPicModel.ImageURL= commentContentPicUpdateModel.ImageURL;
            await _context.SaveChangesAsync();
            return Ok(commentContentPicModel.ToCommentContentPicDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentContentPicModel = _context.CommentContentPic.FirstOrDefault(x => x.CommentContentPicID == id);
            if (commentContentPicModel == null) 
            {
                return NotFound();
            }
            _context.CommentContentPic.Remove(commentContentPicModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}