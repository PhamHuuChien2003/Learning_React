using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentPic;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/commentcontentpic")]
    [ApiController]
    public class CommentContentPicController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICommentContentPicRepository _commentContentPicRepository;
        public CommentContentPicController(ApplicationDBContext context , ICommentContentPicRepository commentContentPicRepository)
        {
            _commentContentPicRepository = commentContentPicRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentContentPic =await _commentContentPicRepository.GetAllAsync();
            var commentContentPicDto = commentContentPic.Select(s => s.ToCommentContentPicDto());

            return Ok(commentContentPicDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentContentPic =await _commentContentPicRepository.GetByIdAsync(id);

            if (commentContentPic == null)
            {
                return NotFound();
            }

            return Ok(commentContentPic.ToCommentContentPicDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentContentPicRequestDto createCommentContentPicDto)
        {
            var commentContentPicModel = createCommentContentPicDto.ToCommentContentPicFromCreateDTO();
            await _commentContentPicRepository.CreateAsync(commentContentPicModel);
            return CreatedAtAction(nameof(GetById),new { id= commentContentPicModel.CommentContentPicID}, commentContentPicModel.ToCommentContentPicDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentContentPicRequestDto updateCommentContentPicDto)
        {
            var commentContentPicModel =await _commentContentPicRepository.UpdateAsync(id,updateCommentContentPicDto);
            if (commentContentPicModel == null) 
            {
                return NotFound();
            }
            return Ok(commentContentPicModel.ToCommentContentPicDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var commentContentPicModel = await _commentContentPicRepository.DeleteAsync(id);
            if (commentContentPicModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}