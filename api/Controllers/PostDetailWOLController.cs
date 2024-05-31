using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailWOL;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/postdetailwol")]
    [ApiController]
    public class PostDetailWOLController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IPostDetailWOLRepository _postDetailWOLRepo;
        public PostDetailWOLController(ApplicationDBContext context, IPostDetailWOLRepository postDetailWOLRepo)
        {
            _context = context;
            _postDetailWOLRepo = postDetailWOLRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailWOL =await _postDetailWOLRepo.GetAllAsync();
            var postDetailWOLDto = postDetailWOL.Select(s => s.ToPostDetailWOLDto());

            return Ok(postDetailWOLDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailWOL =await _postDetailWOLRepo.GetByIdAsync(id);

            if (postDetailWOL == null)
            {
                return NotFound();
            }

            return Ok(postDetailWOL.ToPostDetailWOLDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDetailWOLRequestDto createPostDetailWOLDto)
        {
            var postDetailWOLModel = createPostDetailWOLDto.ToPostDetailWOLFromCreateDTO();
            await _postDetailWOLRepo.CreateAsync(postDetailWOLModel);
            return CreatedAtAction(nameof(GetById), new {id=postDetailWOLModel.PostDetailWOLID}, postDetailWOLModel.ToPostDetailWOLDto());

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailWOLRequestDto updatePostDetailWOLDto)
        {
            var postDetailWOLModel =await _postDetailWOLRepo.UpdateAsync(id, updatePostDetailWOLDto);
            if (postDetailWOLModel == null) 
            {
                return NotFound();
            }
            return Ok(postDetailWOLModel.ToPostDetailWOLDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailWOLModel = _postDetailWOLRepo.DeleteAsync(id);
            if (postDetailWOLModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}