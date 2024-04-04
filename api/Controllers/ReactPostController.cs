using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.ReactPost;
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
        public ReactPostController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reactPost =await _context.ReactPost.ToListAsync();
            var reactPostDto = reactPost.Select(s => s.ToReactPostDto());

            return Ok(reactPostDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var reactPost =await _context.ReactPost.FindAsync(id);

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
            await _context.ReactPost.AddAsync(reactPostModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= reactPostModel.ReactPostID}, reactPostModel.ToReactPostDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateReactPostRequestDto updateReactPostDto)
        {
            var reactPostModel =await  _context.ReactPost.FirstOrDefaultAsync(x => x.ReactPostID == id);
            if (reactPostModel == null) 
            {
                return NotFound();
            }
            var reactPostUpdateModel = updateReactPostDto.ToReactPostFromUpdateDTO();
            reactPostModel.Type = reactPostUpdateModel.Type;
            await _context.SaveChangesAsync();
            return Ok(reactPostModel.ToReactPostDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var reactPostModel = _context.ReactPost.FirstOrDefault(x => x.ReactPostID == id);
            if (reactPostModel == null) 
            {
                return NotFound();
            }
            _context.ReactPost.Remove(reactPostModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}