using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailSGPicWithCaption;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/postdetailsgpicwithcaption")]
    [ApiController]
    public class PostDetailSGPicWithCaptionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailSGPicWithCaptionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDetailSGPicWithCaption = _context.PostDetailSGPicWithCaption.ToList()
                .Select(s => s.ToPostDetailSGPicWithCaptionDto());

            return Ok(postDetailSGPicWithCaption);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailSGPicWithCaption = _context.PostDetailSGPicWithCaption.Find(id);

            if (postDetailSGPicWithCaption == null)
            {
                return NotFound();
            }

            return Ok(postDetailSGPicWithCaption.ToPostDetailSGPicWithCaptionDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreatePostDetailSGPicWithCaptionRequestDto createPostDetailSGPicWithCaptiontDto)
        {
            var postDetailSGPicWithCaptionModel = createPostDetailSGPicWithCaptiontDto.ToPostDetailSGPicWithCaptionFromCreateDTO();
            _context.PostDetailSGPicWithCaption.Add(postDetailSGPicWithCaptionModel);
            _context.SaveChanges();
             return CreatedAtAction(nameof(GetById),new { id= postDetailSGPicWithCaptionModel.PostDetailSGPicWithCaptionID}, postDetailSGPicWithCaptionModel.ToPostDetailSGPicWithCaptionDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdatePostDetailSGPicWithCaptionRequestDto updatePostDetailSGPicWithCaptionDto)
        {
            var postDetailSGPicWithCaptionModel = _context.PostDetailSGPicWithCaption.FirstOrDefault(x => x.PostDetailSGPicWithCaptionID == id);
            if (postDetailSGPicWithCaptionModel == null) 
            {
                return NotFound();
            }
            postDetailSGPicWithCaptionModel = updatePostDetailSGPicWithCaptionDto.ToPostDetailSGPicWithCaptionFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= postDetailSGPicWithCaptionModel.PostDetailSGPicWithCaptionID}, postDetailSGPicWithCaptionModel.ToPostDetailSGPicWithCaptionDto());
        }
    }
}