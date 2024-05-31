using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailAlbum;
using api.Interfaces;
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
        private readonly IPostDetailAlbumRepository _postDetailAlbumRepo;
        public PostDetailAlbumController(ApplicationDBContext context, IPostDetailAlbumRepository postDetailAlbumRepo)
        {
            _context = context;
            _postDetailAlbumRepo = postDetailAlbumRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDetailAlbum =await _postDetailAlbumRepo.GetAllAsync();
            var postDetailAlbumDto = postDetailAlbum.Select(s => s.ToPostDetailAlbumDto());

            return Ok(postDetailAlbumDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postDetailAlbum =await _postDetailAlbumRepo.GetByIdAsync(id);

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
            await _postDetailAlbumRepo.CreateAsync(postDetailAlbumModel);
            return CreatedAtAction(nameof(GetById),new { id= postDetailAlbumModel.PostDetailAlbumID}, postDetailAlbumModel.ToPostDetailAlbumDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdatePostDetailAlbumRequestDto updatePostDetailAlbumDto)
        {
            var postDetailAlbumModel =await _postDetailAlbumRepo.UpdateAsync(id, updatePostDetailAlbumDto);
            if (postDetailAlbumModel == null) 
            {
                return NotFound();
            }
            return Ok(postDetailAlbumModel.ToPostDetailAlbumDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var postDetailAlbumModel = _postDetailAlbumRepo.DeleteAsync(id);
            if (postDetailAlbumModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}