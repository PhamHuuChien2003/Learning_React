using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.RelationshipMember;
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
        public RelationshipMemberController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relationshipMember =await _context.RelationshipMember.ToListAsync();
            var relationshipMemberDto = relationshipMember.Select(s => s.ToRelationshipMemberDto());

            return Ok(relationshipMemberDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var relationshipMember =await _context.RelationshipMember.FindAsync(id);

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
            await _context.RelationshipMember.AddAsync(relationshipMemberModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= relationshipMemberModel.RelationshipMemberId}, relationshipMemberModel.ToRelationshipMemberDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRelationshipMemberRequestDto updateRelationshipMemberDto)
        {
            var relationshipMemberModel =await _context.RelationshipMember.FirstOrDefaultAsync(x => x.RelationshipMemberId == id);
            if (relationshipMemberModel == null) 
            {
                return NotFound();
            }
            var relationshipMemberUpdateModel = updateRelationshipMemberDto.ToRelationshipMemberFromUpdateDTO();
            relationshipMemberModel.UserId = relationshipMemberUpdateModel.UserId;
            relationshipMemberModel.RelationshipId = relationshipMemberUpdateModel.RelationshipId;
            await _context.SaveChangesAsync();
            return Ok(relationshipMemberModel.ToRelationshipMemberDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var relationshipMemberModel = _context.RelationshipMember.FirstOrDefault(x => x.RelationshipMemberId == id);
            if (relationshipMemberModel == null) 
            {
                return NotFound();
            }
            _context.RelationshipMember.Remove(relationshipMemberModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}