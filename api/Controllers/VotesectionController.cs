using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Votesection;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var  votesection =await _context. Votesection.ToListAsync();
            var votesectionDto = votesection.Select(s => s.ToVotesectionDto());

            return Ok( votesectionDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var  votesection =await _context. Votesection.FindAsync(id);

            if ( votesection == null)
            {
                return NotFound();
            }

            return Ok( votesection.ToVotesectionDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVoteSectionRequestDto createVoteSectionDto)
        {
            var votesectionModel = createVoteSectionDto.ToVoteSectionFromCreateDTO();
            await _context.Votesection.AddAsync(votesectionModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= votesectionModel.VotesectionID}, votesectionModel.ToVotesectionDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateVoteSectionRequestDto updateVotesectionDto)
        {
            var votesectionModel = await _context.Votesection.FirstOrDefaultAsync(x => x.VotesectionID == id);
            if (votesectionModel == null) 
            {
                return NotFound();
            }
            var votesectionUpdateModel = updateVotesectionDto.ToVoteSectionFromUpdateDTO();
            votesectionModel.VoteName = votesectionUpdateModel.VoteName;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= votesectionModel.VotesectionID}, votesectionModel.ToVotesectionDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var votesectionModel = _context.Votesection.FirstOrDefault(x => x.VotesectionID == id);
            if (votesectionModel == null) 
            {
                return NotFound();
            }
            _context.Votesection.Remove(votesectionModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}