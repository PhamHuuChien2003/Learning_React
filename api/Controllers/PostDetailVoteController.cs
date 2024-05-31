using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVote;
using api.Interfaces;
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
        private readonly IPostDetailVoteRepository _postDetailVoteRepo;
        public PostDetailVoteController(ApplicationDBContext context, IPostDetailVoteRepository postDetailVoteRepo)
        {
            _context = context;
            _postDetailVoteRepo = postDetailVoteRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailVote =await _postDetailVoteRepo.GetAllAsync();
            var postDetailVoteDto = postDetailVote.Select(s => s.ToPostDetailVoteDto());

            return Ok(postDetailVoteDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailVote =await _postDetailVoteRepo.GetByIdAsync(id);

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
            await _postDetailVoteRepo.CreateAsync(postDetailVoteModel);
            return CreatedAtAction(nameof(GetById),new{id=postDetailVoteModel.PostDetailVoteID},postDetailVoteModel.ToPostDetailVoteDto());
            
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailVoteRequestDto updatePostDetailVoteDto)
        {
            var postDetailVoteModel =await _postDetailVoteRepo.UpdateAsync(id, updatePostDetailVoteDto);
            if (postDetailVoteModel == null) 
            {
                return NotFound();
            }
            return Ok(postDetailVoteModel.ToPostDetailVoteDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailVoteModel = _postDetailVoteRepo.DeleteAsync(id);
            if (postDetailVoteModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}