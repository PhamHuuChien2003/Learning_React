using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentVideo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/commentcontentvideo")]
    [ApiController]
    public class CommentContentVideoController : ControllerBase
    {
        private readonly ICommentContentVideoRepository _commentcontentVidRepo;
        private readonly ApplicationDBContext _context;
        public CommentContentVideoController(ApplicationDBContext context, ICommentContentVideoRepository commentcontentVidRepo)
        {
            _context = context;
            _commentcontentVidRepo = commentcontentVidRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentContentVideo =await _commentcontentVidRepo.GetAllAsync();
            var commentContentVideoDto =commentContentVideo.Select(s => s.ToCommentContentVideoDto());

            return Ok(commentContentVideoDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentContentVideo =await _commentcontentVidRepo.GetByIdAsync(id);

            if (commentContentVideo == null)
            {
                return NotFound();
            }

            return Ok(commentContentVideo.ToCommentContentVideoDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentContentVideoRequestDto createCommentContentVideoDto)
        {
            var commentContentVideoModel = createCommentContentVideoDto.ToCommentContentVideoFromCreateDTO();
            await _commentcontentVidRepo.CreateAsync(commentContentVideoModel);
            return CreatedAtAction(nameof(GetById), new { id=commentContentVideoModel.CommentContentVideoID},commentContentVideoModel.ToCommentContentVideoDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentContentVideoRequestDto updateCommentContentVideoDto)
        {
            var commentContentVideoModel = await _commentcontentVidRepo.UpdateAsync(id, updateCommentContentVideoDto);
            if (commentContentVideoModel == null) 
            {
                return NotFound();
            }
            return Ok(commentContentVideoModel.ToCommentContentVideoDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentContentVideoModel = _commentcontentVidRepo.DeleteAsync(id);
            if (commentContentVideoModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}