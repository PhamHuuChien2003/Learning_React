using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVote;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/postdetailvote")]
    [ApiController]
    public class PostDetailVoteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVoteController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailVote =await _context.PostDetailVote.ToListAsync();
            var postDetailVoteDto = postDetailVote.Select(s => s.ToPostDetailVoteDto());

            return Ok(postDetailVoteDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailVote =await _context.PostDetailVote.FindAsync(id);

            if (postDetailVote == null)
            {
                return NotFound();
            }

            return Ok(postDetailVote.ToPostDetailVoteDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDetailVoteRequestDto createPostDetailVoteDto)
        {
            var postDetailVoteModel = createPostDetailVoteDto.ToPostDetailVoteFromCreateDTO();
            await _context.PostDetailVote.AddAsync(postDetailVoteModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new{id=postDetailVoteModel.PostDetailVoteID},postDetailVoteModel.ToPostDetailVoteDto());
            
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailVoteRequestDto updatePostDetailVoteDto)
        {
            var postDetailVoteModel =await _context.PostDetailVote.FirstOrDefaultAsync(x => x.PostDetailVoteID == id);
            if (postDetailVoteModel == null) 
            {
                return NotFound();
            }
            var postDetailVoteUpdateModel = updatePostDetailVoteDto.ToPostDetailVoteFromUpdateDTO();
            postDetailVoteModel.Content = postDetailVoteUpdateModel.Content;
            postDetailVoteUpdateModel.HashTag = postDetailVoteUpdateModel.HashTag;
            await _context.SaveChangesAsync();
            return Ok(postDetailVoteModel.ToPostDetailVoteDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailVoteModel = _context.PostDetailVote.FirstOrDefault(x => x.PostDetailVoteID == id);
            if (postDetailVoteModel == null) 
            {
                return NotFound();
            }
            _context.PostDetailVote.Remove(postDetailVoteModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}