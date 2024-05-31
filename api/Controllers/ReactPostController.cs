using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.ReactPost;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/reactpost")]
    [ApiController]
    public class ReactPostController  : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IReactPostRepository _reactPostRepo;
        public ReactPostController(ApplicationDBContext context, IReactPostRepository reactPostRepo)
        {
            _context = context;
            _reactPostRepo = reactPostRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reactPost =await _reactPostRepo.GetAllAsync();
            var reactPostDto = reactPost.Select(s => s.ToReactPostDto());

            return Ok(reactPostDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var reactPost =await _reactPostRepo.GetByIdAsync(id);

            if (reactPost == null)
            {
                return NotFound();
            }

            return Ok(reactPost.ToReactPostDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReactPostRequestDto createReactPostDto)
        {
            var reactPostModel = createReactPostDto.ToReactPostFromCreateDTO();
            await _reactPostRepo.CreateAsync(reactPostModel);
            return CreatedAtAction(nameof(GetById),new { id= reactPostModel.ReactPostID}, reactPostModel.ToReactPostDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateReactPostRequestDto updateReactPostDto)
        {
            var reactPostModel =await  _reactPostRepo.UpdateAsync(id, updateReactPostDto);
            if (reactPostModel == null) 
            {
                return NotFound();
            }
            return Ok(reactPostModel.ToReactPostDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var reactPostModel = _reactPostRepo.DeleteAsync(id);
            if (reactPostModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}