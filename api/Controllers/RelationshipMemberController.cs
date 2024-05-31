using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.RelationshipMember;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/relationshipmember")]
    [ApiController]
    public class RelationshipMemberController  : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRelationshipMemberRepository _relationshipRepo;
        public RelationshipMemberController(ApplicationDBContext context, IRelationshipMemberRepository relationshipRepo)
        {
            _context = context;
            _relationshipRepo = relationshipRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relationshipMember =await _relationshipRepo.GetAllAsync();
            var relationshipMemberDto = relationshipMember.Select(s => s.ToRelationshipMemberDto());

            return Ok(relationshipMemberDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var relationshipMember =await _relationshipRepo.GetByIdAsync(id);

            if (relationshipMember == null)
            {
                return NotFound();
            }

            return Ok(relationshipMember.ToRelationshipMemberDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRelationshipMemberRequestDto createRelationshipMemberDto)
        {
            var relationshipMemberModel = createRelationshipMemberDto.ToRelationshipMemberFromCreateDTO();
            await _relationshipRepo.CreateAsync(relationshipMemberModel);
            return CreatedAtAction(nameof(GetById),new { id= relationshipMemberModel.RelationshipMemberId}, relationshipMemberModel.ToRelationshipMemberDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRelationshipMemberRequestDto updateRelationshipMemberDto)
        {
            var relationshipMemberModel =await _relationshipRepo.UpdateAsync(id,updateRelationshipMemberDto);
            if (relationshipMemberModel == null) 
            {
                return NotFound();
            }
            return Ok(relationshipMemberModel.ToRelationshipMemberDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var relationshipMemberModel = _relationshipRepo.DeleteAsync(id);
            if (relationshipMemberModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}