using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentPic;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/commentcontentpic")]
    [ApiController]
    public class CommentContentPicController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CommentContentPicController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var commentContentPic = _context.CommentContentPic.ToList()
                .Select(s => s.ToCommentContentPicDto());

            return Ok(commentContentPic);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var commentContentPic = _context.CommentContentPic.Find(id);

            if (commentContentPic == null)
            {
                return NotFound();
            }

            return Ok(commentContentPic.ToCommentContentPicDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCommentContentPicRequestDto createCommentContentPicDto)
        {
            var commentContentPicModel = createCommentContentPicDto.ToCommentContentPicFromCreateDTO();
            _context.CommentContentPic.Add(commentContentPicModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= commentContentPicModel.CommentContentPicID}, commentContentPicModel.ToCommentContentPicDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateCommentContentPicRequestDto updateCommentContentPicDto)
        {
            var commentContentPicModel = _context.CommentContentPic.FirstOrDefault(x => x.CommentContentPicID == id);
            if (commentContentPicModel == null) 
            {
                return NotFound();
            }
            commentContentPicModel = updateCommentContentPicDto.ToCommentContentPicFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= commentContentPicModel.CommentContentPicID}, commentContentPicModel.ToCommentContentPicDto());
        }
    }
}