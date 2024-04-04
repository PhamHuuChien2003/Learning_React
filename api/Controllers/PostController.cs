using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Post;
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
        public PostController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var post =await _context.Post.ToListAsync();
            var postDto= post.Select(s => s.ToPostDto());

            return Ok(postDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post =await _context.Post.FindAsync(id);

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
            await _context.Post.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new{id=postModel.PostId},postModel.ToPostDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostRequestDto updatePostDto)
        {
            var postModel =await _context.Post.FirstOrDefaultAsync(x => x.PostId == id);
            if (postModel == null) 
            {
                return NotFound();
            }
            var postUpdateModel = updatePostDto.ToPostFromUpdateDTO();
            postModel.Type = postUpdateModel.Type;
            await _context.SaveChangesAsync();
            return Ok(postModel.ToPostDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postModel = _context.Post.FirstOrDefault(x => x.PostId == id);
            if (postModel == null) 
            {
                return NotFound();
            }
            _context.Post.Remove(postModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}