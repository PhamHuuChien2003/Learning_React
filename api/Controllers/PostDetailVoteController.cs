using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVote;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/postdetailvote")]
    [ApiController]
    public class PostDetailVoteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVoteController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDetailVote = _context.PostDetailVote.ToList()
                .Select(s => s.ToPostDetailVoteDto());

            return Ok(postDetailVote);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailVote = _context.PostDetailVote.Find(id);

            if (postDetailVote == null)
            {
                return NotFound();
            }

            return Ok(postDetailVote.ToPostDetailVoteDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreatePostDetailVoteRequestDto createPostDetailVoteDto)
        {
            var postDetailVoteModel = createPostDetailVoteDto.ToPostDetailVoteFromCreateDTO();
            _context.PostDetailVote.Add(postDetailVoteModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new{id=postDetailVoteModel.PostDetailVoteID},postDetailVoteModel.ToPostDetailVoteDto());
            
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdatePostDetailVoteRequestDto updatePostDetailVoteDto)
        {
            var postDetailVoteModel = _context.PostDetailVote.FirstOrDefault(x => x.PostDetailVoteID == id);
            if (postDetailVoteModel == null) 
            {
                return NotFound();
            }
            postDetailVoteModel = updatePostDetailVoteDto.ToPostDetailVoteFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= postDetailVoteModel.PostDetailVoteID}, postDetailVoteModel.ToPostDetailVoteDto());
        }
    }
}