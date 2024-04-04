using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailWOL;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/postdetailwol")]
    [ApiController]
    public class PostDetailWOLController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailWOLController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailWOL =await _context.PostDetailWOL.ToListAsync();
            var postDetailWOLDto = postDetailWOL.Select(s => s.ToPostDetailWOLDto());

            return Ok(postDetailWOLDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailWOL =await _context.PostDetailWOL.FindAsync(id);

            if (postDetailWOL == null)
            {
                return NotFound();
            }

            return Ok(postDetailWOL.ToPostDetailWOLDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDetailWOLRequestDto createPostDetailWOLDto)
        {
            var postDetailWOLModel = createPostDetailWOLDto.ToPostDetailWOLFromCreateDTO();
            await _context.PostDetailWOL.AddAsync(postDetailWOLModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id=postDetailWOLModel.PostDetailWOLID}, postDetailWOLModel.ToPostDetailWOLDto());

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailWOLRequestDto updatePostDetailWOLDto)
        {
            var postDetailWOLModel =await _context.PostDetailWOL.FirstOrDefaultAsync(x => x.PostDetailWOLID == id);
            if (postDetailWOLModel == null) 
            {
                return NotFound();
            }
            var postDetailWOLUpdateModel = updatePostDetailWOLDto.ToPostDetailWOLFromUpdateDTO();
            postDetailWOLModel.Content = postDetailWOLUpdateModel.Content;
            postDetailWOLModel.HashTag = postDetailWOLUpdateModel.HashTag;
            await _context.SaveChangesAsync();
            return Ok(postDetailWOLModel.ToPostDetailWOLDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailWOLModel = _context.PostDetailWOL.FirstOrDefault(x => x.PostDetailWOLID == id);
            if (postDetailWOLModel == null) 
            {
                return NotFound();
            }
            _context.PostDetailWOL.Remove(postDetailWOLModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}