using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailAlbum;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var postDetailAlbum = _context.PostDetailAlbum.ToList()
                .Select(s => s.ToPostDetailAlbumDto());

            return Ok(postDetailAlbum);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailAlbum = _context.PostDetailAlbum.Find(id);

            if (postDetailAlbum == null)
            {
                return NotFound();
            }

            return Ok(postDetailAlbum.ToPostDetailAlbumDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreatePostDetailAlbumRequestDto createPostDetailAlbumDto)
        {
            var postDetailAlbumModel = createPostDetailAlbumDto.ToPostDetailAlbumFromCreateDTO();
            _context.PostDetailAlbum.Add(postDetailAlbumModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= postDetailAlbumModel.PostDetailAlbumID}, postDetailAlbumModel.ToPostDetailAlbumDto());
        }
    }
}