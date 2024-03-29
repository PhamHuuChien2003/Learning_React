using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/postdetailwol")]
    [ApiController]
    public class PostDetailWOLController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PostDetailWOLController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var postDetailWOL = _context.PostDetailWOL.ToList()
                .Select(s => s.ToPostDetailWOLDto());

            return Ok(postDetailWOL);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var postDetailWOL = _context.PostDetailWOL.Find(id);

            if (postDetailWOL == null)
            {
                return NotFound();
            }

            return Ok(postDetailWOL.ToPostDetailWOLDto());
        }
    }
}