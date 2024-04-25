using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailSGPicWithCaption;
using api.Interfaces;
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
        private readonly IPostDetailSGPicWithCaptionRepository _postDetailSGPicWithCaptionRepo;
        public PostDetailSGPicWithCaptionController(ApplicationDBContext context, IPostDetailSGPicWithCaptionRepository postDetailSGPicWithCaptionRepo)
        {
            _context = context;
            _postDetailSGPicWithCaptionRepo = postDetailSGPicWithCaptionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailSGPicWithCaption =await  _postDetailSGPicWithCaptionRepo.GetAllAsync();
            var postDetailSGPicWithCaptionDto = postDetailSGPicWithCaption.Select(s => s.ToPostDetailSGPicWithCaptionDto());

            return Ok(postDetailSGPicWithCaptionDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailSGPicWithCaption =await _postDetailSGPicWithCaptionRepo.GetByIdAsync(id);

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
            await _postDetailSGPicWithCaptionRepo.CreateAsync(postDetailSGPicWithCaptionModel);
             return CreatedAtAction(nameof(GetById),new { id= postDetailSGPicWithCaptionModel.PostDetailSGPicWithCaptionID}, postDetailSGPicWithCaptionModel.ToPostDetailSGPicWithCaptionDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailSGPicWithCaptionRequestDto updatePostDetailSGPicWithCaptionDto)
        {
            var postDetailSGPicWithCaptionModel =await _postDetailSGPicWithCaptionRepo.UpdateAsync(id, updatePostDetailSGPicWithCaptionDto);
            if (postDetailSGPicWithCaptionModel == null) 
            {
                return NotFound();
            }
            return Ok(postDetailSGPicWithCaptionModel.ToPostDetailSGPicWithCaptionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailSGPicWithCaptionModel = _postDetailSGPicWithCaptionRepo.DeleteAsync(id);
            if (postDetailSGPicWithCaptionModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}