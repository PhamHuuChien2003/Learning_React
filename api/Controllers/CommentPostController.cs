using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentPost;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var commentPost =await _context.CommentPost.ToListAsync();
            var commentPostDto = commentPost.Select(s => s.ToCommentPostDto());

            return Ok(commentPostDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentPost =await _context.CommentPost.FindAsync(id);

            if (commentPost == null)
            {
                return NotFound();
            }

            return Ok(commentPost.ToCommentPostDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentPostRequestDto createCommentPostDto)
        {
            var commentPostModel = createCommentPostDto.ToCommentPostFromCreateDTO();
            await _context.CommentPost.AddAsync(commentPostModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = commentPostModel.CommentPostID},commentPostModel.ToCommentPostDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentPostRequestDto updateCommentPostDto)
        {
            var commentPostModel =await _context.CommentPost.FirstOrDefaultAsync(x => x.CommentPostID == id);
            if (commentPostModel == null) 
            {
                return NotFound();
            }
            var commentPostUpdateModel = updateCommentPostDto.ToCommentPostFromUpdateDTO();
            commentPostModel.Type= commentPostUpdateModel.Type;
            await _context.SaveChangesAsync();
            return Ok(commentPostModel.ToCommentPostDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentPostModel = _context.CommentPost.FirstOrDefault(x => x.CommentPostID == id);
            if (commentPostModel == null) 
            {
                return NotFound();
            }
            _context.CommentPost.Remove(commentPostModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}