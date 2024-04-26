using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.VoteResult;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/voteresult")]
    [ApiController]
    public class VoteResultController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IVoteResultRepository _voteResultRepo;
        public VoteResultController(ApplicationDBContext context, IVoteResultRepository voteResultRepo)
        {
            _context = context;
            _voteResultRepo = voteResultRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  voteResult =await _voteResultRepo.GetAllAsync();
            var voteResultDto = voteResult.Select(s => s.ToVoteResultDto());

            return Ok( voteResultDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var  voteResult =await _voteResultRepo.GetByIdAsync(id);

            if ( voteResult == null)
            {
                return NotFound();
            }

            return Ok( voteResult.ToVoteResultDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVoteResultRequestDto createVoteResultRequestDto)
        {
            var voteResultModel = createVoteResultRequestDto.ToVoteResultFromCreateDTO();
            await _voteResultRepo.CreateAsync(voteResultModel);
            return CreatedAtAction(nameof(GetById),new { id= voteResultModel.VoteResultID}, voteResultModel.ToVoteResultDto());
        }


        // [HttpPut]
        // [Route("{id}")]
        // public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateVoteResultRequestDto updateVoteResultDto)
        // {
        //     var voteResultModel =await _context.VoteResult.FirstOrDefaultAsync(x => x.VoteResultID == id);
        //     if (voteResultModel == null) 
        //     {
        //         return NotFound();
        //     }
        //     var voteResultUpdateModel = updateVoteResultDto.ToVoteResultFromUpdateDTO();
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction(nameof(GetById),new { id= voteResultModel.VoteResultID}, voteResultModel.ToVoteResultDto());
        // }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var voteResultModel = _voteResultRepo.DeleteAsync(id);
            if (voteResultModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}