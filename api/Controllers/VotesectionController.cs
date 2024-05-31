using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Votesection;
using api.Interfaces;
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
        private readonly IVotesectionRepository _votesectionRepo;
        public VotesectionController(ApplicationDBContext context,IVotesectionRepository votesectionRepo)
        {
            _context = context;
            _votesectionRepo = votesectionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  votesection =await _votesectionRepo.GetAllAsync();
            var votesectionDto = votesection.Select(s => s.ToVotesectionDto());

            return Ok( votesectionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var  votesection =await _votesectionRepo.GetByIdAsync(id);

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
            await _votesectionRepo.CreateAsync(votesectionModel);
            return CreatedAtAction(nameof(GetById),new { id= votesectionModel.VotesectionID}, votesectionModel.ToVotesectionDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateVoteSectionRequestDto updateVotesectionDto)
        {
            var votesectionModel = await _votesectionRepo.UpdateAsync(id, updateVotesectionDto);
            if (votesectionModel == null) 
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById),new { id= votesectionModel.VotesectionID}, votesectionModel.ToVotesectionDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var votesectionModel = _votesectionRepo.DeleteAsync(id);
            if (votesectionModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}