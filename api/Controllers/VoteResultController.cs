using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.VoteResult;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/voteresult")]
    [ApiController]
    public class VoteResultController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VoteResultController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var  voteResult = _context. VoteResult.ToList()
                .Select(s => s.ToVoteResultDto());

            return Ok( voteResult);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var  voteResult = _context. VoteResult.Find(id);

            if ( voteResult == null)
            {
                return NotFound();
            }

            return Ok( voteResult.ToVoteResultDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateVoteResultRequestDto createVoteResultRequestDto)
        {
            var voteResultModel = createVoteResultRequestDto.ToVoteResultFromCreateDTO();
            _context.VoteResult.Add(voteResultModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= voteResultModel.VoteResultID}, voteResultModel.ToVoteResultDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateVoteResultRequestDto updateVoteResultDto)
        {
            var voteResultModel = _context.VoteResult.FirstOrDefault(x => x.VoteResultID == id);
            if (voteResultModel == null) 
            {
                return NotFound();
            }
            voteResultModel = updateVoteResultDto.ToVoteResultFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= voteResultModel.VoteResultID}, voteResultModel.ToVoteResultDto());
        }
    }
}