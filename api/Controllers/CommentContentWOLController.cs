using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentWOL;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var commentContentWOL = _context.CommentContentWOL.ToList()
                .Select(s => s.ToCommentContentWOLDto());

            return Ok(commentContentWOL);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var commentContentWOL = _context.CommentContentWOL.Find(id);

            if (commentContentWOL == null)
            {
                return NotFound();
            }

            return Ok(commentContentWOL.ToCommentContentWOLDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCommentContentWOLRequestDto createCommentContentWOLDto)
        {
            var commentContentWOLModel = createCommentContentWOLDto.ToCommentContentWOLFromCreateDTO();
            _context.CommentContentWOL.Add(commentContentWOLModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = commentContentWOLModel.CommentContentWOLID}, commentContentWOLModel.ToCommentContentWOLDto());
        }
    }
}