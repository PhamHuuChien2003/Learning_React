using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVideoAndCaption;
using api.Interfaces;
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
        private readonly IPostDetailVideoAndCaptionRepository _postDetailVideoAndCaptionRepo;
        public PostDetailVideoAndCaptionController(ApplicationDBContext context, IPostDetailVideoAndCaptionRepository postDetailVideoAndCaptionRepo)
        {
            _context = context;
            _postDetailVideoAndCaptionRepo = postDetailVideoAndCaptionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailVideoAndCaption =await _postDetailVideoAndCaptionRepo.GetAllAsync();
            var postDetailVideoAndCaptionDto = postDetailVideoAndCaption.Select(s => s.ToPostDetailVideoAndCaptionDto());

            return Ok(postDetailVideoAndCaptionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailVideoAndCaption =await _postDetailVideoAndCaptionRepo.GetByIdAsync(id);

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
            await _postDetailVideoAndCaptionRepo.CreateAsync(postDetailVideoAndCaptionModel);
            return CreatedAtAction(nameof(GetById), new{id=postDetailVideoAndCaptionModel.PostDetailVideoAndCaptionID},postDetailVideoAndCaptionModel.ToPostDetailVideoAndCaptionDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailVideoAndCaptionRequestDto updatePostDetailVideoAndCaptionDto)
        {
            var postDetailVideoAndCaptionModel =await  _postDetailVideoAndCaptionRepo.UpdateAsync(id, updatePostDetailVideoAndCaptionDto);
            if (postDetailVideoAndCaptionModel == null) 
            {
                return NotFound();
            }
            return Ok(postDetailVideoAndCaptionModel.ToPostDetailVideoAndCaptionDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailVideoAndCaptionModel = _postDetailVideoAndCaptionRepo.DeleteAsync(id);
            if (postDetailVideoAndCaptionModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}