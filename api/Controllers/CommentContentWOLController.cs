using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentWOL;
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
        public CommentContentWOLController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentContentWOL =await _context.CommentContentWOL.ToListAsync();
            var commentContentWOLDto = commentContentWOL.Select(s => s.ToCommentContentWOLDto());

            return Ok(commentContentWOLDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentContentWOL =await _context.CommentContentWOL.FindAsync(id);

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
            await _context.CommentContentWOL.AddAsync(commentContentWOLModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = commentContentWOLModel.CommentContentWOLID}, commentContentWOLModel.ToCommentContentWOLDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentContentWOLRequestDto updateCommentContentWOLDto)
        {
            var commentContentWOLModel =await _context.CommentContentWOL.FirstOrDefaultAsync(x => x.CommentContentWOLID == id);
            if (commentContentWOLModel == null) 
            {
                return NotFound();
            }
            var commentContentWOLUpdateModel = updateCommentContentWOLDto.ToCommentContentWOLFromUpdateDTO();
            commentContentWOLModel.CommentContent = commentContentWOLUpdateModel.CommentContent;
            await _context.SaveChangesAsync();
            return Ok(commentContentWOLModel.ToCommentContentWOLDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var commentContentWOLModel = _context.CommentContentWOL.FirstOrDefault(x => x.CommentContentWOLID == id);
            if (commentContentWOLModel == null) 
            {
                return NotFound();
            }
            _context.CommentContentWOL.Remove(commentContentWOLModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}