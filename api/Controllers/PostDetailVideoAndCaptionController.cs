using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVideoAndCaption;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/postdetailvideoandcaption")]
    [ApiController]
    public class PostDetailVideoAndCaptionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVideoAndCaptionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailVideoAndCaption =await _context.PostDetailVideoAndCaption.ToListAsync();
            var postDetailVideoAndCaptionDto = postDetailVideoAndCaption.Select(s => s.ToPostDetailVideoAndCaptionDto());

            return Ok(postDetailVideoAndCaptionDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailVideoAndCaption =await _context.PostDetailVideoAndCaption.FindAsync(id);

            if (postDetailVideoAndCaption == null)
            {
                return NotFound();
            }

            return Ok(postDetailVideoAndCaption.ToPostDetailVideoAndCaptionDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDetailVideoAndCaptionRequestDto createPostDetailVideoAndCaptionDto)
        {
            var postDetailVideoAndCaptionModel = createPostDetailVideoAndCaptionDto.ToPostDetailVideoAndCaptionFromCreateDTO();
            await _context.PostDetailVideoAndCaption.AddAsync(postDetailVideoAndCaptionModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new{id=postDetailVideoAndCaptionModel.PostDetailVideoAndCaptionID},postDetailVideoAndCaptionModel.ToPostDetailVideoAndCaptionDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailVideoAndCaptionRequestDto updatePostDetailVideoAndCaptionDto)
        {
            var postDetailVideoAndCaptionModel =await  _context.PostDetailVideoAndCaption.FirstOrDefaultAsync(x => x.PostDetailVideoAndCaptionID == id);
            if (postDetailVideoAndCaptionModel == null) 
            {
                return NotFound();
            }
            var postDetailVideoAndCaptionUpdateModel = updatePostDetailVideoAndCaptionDto.ToPostDetailVideoAndCaptionFromUpdateDTO();
            postDetailVideoAndCaptionModel.Content = postDetailVideoAndCaptionUpdateModel.Content;
            postDetailVideoAndCaptionModel.HashTag = postDetailVideoAndCaptionUpdateModel.HashTag;
            postDetailVideoAndCaptionModel.VideoURL = postDetailVideoAndCaptionUpdateModel.VideoURL;
            await _context.SaveChangesAsync();
            return Ok(postDetailVideoAndCaptionModel.ToPostDetailVideoAndCaptionDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailVideoAndCaptionModel = _context.PostDetailVideoAndCaption.FirstOrDefault(x => x.PostDetailVideoAndCaptionID == id);
            if (postDetailVideoAndCaptionModel == null) 
            {
                return NotFound();
            }
            _context.PostDetailVideoAndCaption.Remove(postDetailVideoAndCaptionModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}