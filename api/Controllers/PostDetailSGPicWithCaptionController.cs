using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailSGPicWithCaption;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/postdetailsgpicwithcaption")]
    [ApiController]
    public class PostDetailSGPicWithCaptionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailSGPicWithCaptionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailSGPicWithCaption =await  _context.PostDetailSGPicWithCaption.ToListAsync();
            var postDetailSGPicWithCaptionDto = postDetailSGPicWithCaption.Select(s => s.ToPostDetailSGPicWithCaptionDto());

            return Ok(postDetailSGPicWithCaptionDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailSGPicWithCaption =await _context.PostDetailSGPicWithCaption.FindAsync(id);

            if (postDetailSGPicWithCaption == null)
            {
                return NotFound();
            }

            return Ok(postDetailSGPicWithCaption.ToPostDetailSGPicWithCaptionDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDetailSGPicWithCaptionRequestDto createPostDetailSGPicWithCaptiontDto)
        {
            var postDetailSGPicWithCaptionModel = createPostDetailSGPicWithCaptiontDto.ToPostDetailSGPicWithCaptionFromCreateDTO();
            await _context.PostDetailSGPicWithCaption.AddAsync(postDetailSGPicWithCaptionModel);
            await _context.SaveChangesAsync();
             return CreatedAtAction(nameof(GetById),new { id= postDetailSGPicWithCaptionModel.PostDetailSGPicWithCaptionID}, postDetailSGPicWithCaptionModel.ToPostDetailSGPicWithCaptionDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailSGPicWithCaptionRequestDto updatePostDetailSGPicWithCaptionDto)
        {
            var postDetailSGPicWithCaptionModel =await _context.PostDetailSGPicWithCaption.FirstOrDefaultAsync(x => x.PostDetailSGPicWithCaptionID == id);
            if (postDetailSGPicWithCaptionModel == null) 
            {
                return NotFound();
            }
            var postDetailSGPicWithCaptionUpdateModel = updatePostDetailSGPicWithCaptionDto.ToPostDetailSGPicWithCaptionFromUpdateDTO();
            postDetailSGPicWithCaptionModel.Content = postDetailSGPicWithCaptionUpdateModel.Content;
            postDetailSGPicWithCaptionModel.HashTag = postDetailSGPicWithCaptionUpdateModel.HashTag;
            postDetailSGPicWithCaptionModel.ImageURL = postDetailSGPicWithCaptionUpdateModel.ImageURL;
            await _context.SaveChangesAsync();
            return Ok(postDetailSGPicWithCaptionModel.ToPostDetailSGPicWithCaptionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailSGPicWithCaptionModel = _context.PostDetailSGPicWithCaption.FirstOrDefault(x => x.PostDetailSGPicWithCaptionID == id);
            if (postDetailSGPicWithCaptionModel == null) 
            {
                return NotFound();
            }
            _context.PostDetailSGPicWithCaption.Remove(postDetailSGPicWithCaptionModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}