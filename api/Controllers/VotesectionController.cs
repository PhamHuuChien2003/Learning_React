using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Votesection;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/votesection")]
    [ApiController]
    public class VotesectionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VotesectionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var  votesection = _context. Votesection.ToList()
                .Select(s => s.ToVotesectionDto());

            return Ok( votesection);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var  votesection = _context. Votesection.Find(id);

            if ( votesection == null)
            {
                return NotFound();
            }

            return Ok( votesection.ToVotesectionDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateVoteSectionRequestDto createVoteSectionDto)
        {
            var votesectionModel = createVoteSectionDto.ToVoteSectionFromCreateDTO();
            _context.Votesection.Add(votesectionModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= votesectionModel.VotesectionID}, votesectionModel.ToVotesectionDto());
        }
    }
}