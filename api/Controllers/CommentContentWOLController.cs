using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentWOL;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/commentcontentwol")]
    [ApiController]
    public class CommentContentWOLController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICommentContentWOLRepository _commentContentWOLRepo;
        public CommentContentWOLController(ApplicationDBContext context, ICommentContentWOLRepository commentContentWOLRepo)
        {
            _context = context;
            _commentContentWOLRepo = commentContentWOLRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentContentWOL =await _commentContentWOLRepo.GetAllAsync();
            var commentContentWOLDto = commentContentWOL.Select(s => s.ToCommentContentWOLDto());

            return Ok(commentContentWOLDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentContentWOL =await _commentContentWOLRepo.GetByIdAsync(id);

            if (commentContentWOL == null)
            {
                return NotFound();
            }

            return Ok(commentContentWOL.ToCommentContentWOLDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentContentWOLRequestDto createCommentContentWOLDto)
        {
            var commentContentWOLModel = createCommentContentWOLDto.ToCommentContentWOLFromCreateDTO();
            await _commentContentWOLRepo.CreateAsync(commentContentWOLModel);
            return CreatedAtAction(nameof(GetById), new {id = commentContentWOLModel.CommentContentWOLID}, commentContentWOLModel.ToCommentContentWOLDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentContentWOLRequestDto updateCommentContentWOLDto)
        {
            var commentContentWOLModel =await _commentContentWOLRepo.UpdateAsync(id, updateCommentContentWOLDto);
            if (commentContentWOLModel == null) 
            {
                return NotFound();
            }
            return Ok(commentContentWOLModel.ToCommentContentWOLDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentContentWOLModel = _commentContentWOLRepo.DeleteAsync(id);
            if (commentContentWOLModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}