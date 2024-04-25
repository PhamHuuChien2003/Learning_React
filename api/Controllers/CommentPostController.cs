using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentPost;
using api.Interfaces;
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
        private readonly ICommentPostRepository _commentPostRepo;
        public CommentPostController(ApplicationDBContext context, ICommentPostRepository commentPostRepo)
        {
            _context = context;
            _commentPostRepo = commentPostRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentPost =await _commentPostRepo.GetAllAsync();
            var commentPostDto = commentPost.Select(s => s.ToCommentPostDto());

            return Ok(commentPostDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentPost =await _commentPostRepo.GetByIdAsync(id);

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
            await _commentPostRepo.CreateAsync(commentPostModel);
            return CreatedAtAction(nameof(GetById), new { id = commentPostModel.CommentPostID},commentPostModel.ToCommentPostDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentPostRequestDto updateCommentPostDto)
        {
            var commentPostModel =await _commentPostRepo.UpdateAsync(id, updateCommentPostDto);
            if (commentPostModel == null) 
            {
                return NotFound();
            }
            return Ok(commentPostModel.ToCommentPostDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentPostModel = _commentPostRepo.DeleteAsync(id);
            if (commentPostModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}