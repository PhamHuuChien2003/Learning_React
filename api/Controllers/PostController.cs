using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Post;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController  : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IPostRepository _postRepo;
        public PostController(ApplicationDBContext context, IPostRepository postRepo)
        {
            _postRepo = postRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var post =await _postRepo.GetAllAsync();
            var postDto= post.Select(s => s.ToPostDto());

            return Ok(postDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post =await _postRepo.GetByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post.ToPostDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto createPostRequestDto)
        {
            var postModel = createPostRequestDto.ToPostFromCreateDTO();
            await _postRepo.CreateAsync(postModel);
            return CreatedAtAction(nameof(GetById),new{id=postModel.PostId},postModel.ToPostDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostRequestDto updatePostDto)
        {
            var postModel =await _postRepo.UpdateAsync(id, updatePostDto);
            if (postModel == null) 
            {
                return NotFound();
            }
            return Ok(postModel.ToPostDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postModel = _postRepo.DeleteAsync(id);
            if (postModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}