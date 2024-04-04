using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailAlbum;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/postdetailalbum")]
    [ApiController]
    public class PostDetailAlbumController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailAlbumController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailAlbum =await _context.PostDetailAlbum.ToListAsync();
            var postDetailAlbumDto = postDetailAlbum.Select(s => s.ToPostDetailAlbumDto());

            return Ok(postDetailAlbum);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailAlbum =await _context.PostDetailAlbum.FindAsync(id);

            if (postDetailAlbum == null)
            {
                return NotFound();
            }

            return Ok(postDetailAlbum.ToPostDetailAlbumDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostDetailAlbumRequestDto createPostDetailAlbumDto)
        {
            var postDetailAlbumModel = createPostDetailAlbumDto.ToPostDetailAlbumFromCreateDTO();
            await _context.PostDetailAlbum.AddAsync(postDetailAlbumModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= postDetailAlbumModel.PostDetailAlbumID}, postDetailAlbumModel.ToPostDetailAlbumDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailAlbumRequestDto updatePostDetailAlbumDto)
        {
            var postDetailAlbumModel =await _context.PostDetailAlbum.FirstOrDefaultAsync(x => x.PostDetailAlbumID == id);
            if (postDetailAlbumModel == null) 
            {
                return NotFound();
            }
            var postDetailAlbumUpdateModel = updatePostDetailAlbumDto.ToPostDetailAlbumFromUpdateDTO();
            postDetailAlbumModel.Content = postDetailAlbumUpdateModel.Content;
            postDetailAlbumModel.HashTag = postDetailAlbumUpdateModel.HashTag;
            postDetailAlbumModel.AlbumURL = postDetailAlbumUpdateModel.AlbumURL;
            await _context.SaveChangesAsync();
            return Ok(postDetailAlbumModel.ToPostDetailAlbumDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailAlbumModel = _context.PostDetailAlbum.FirstOrDefault(x => x.PostDetailAlbumID == id);
            if (postDetailAlbumModel == null) 
            {
                return NotFound();
            }
            _context.PostDetailAlbum.Remove(postDetailAlbumModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}