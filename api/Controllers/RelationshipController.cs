using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Relationship;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/relationship")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public RelationshipController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relationship =await _context.Relationship.ToListAsync();
            var relationshipDto = relationship.Select(s => s.ToRelationshipDto());

            return Ok(relationship);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var relationship =await _context.Relationship.FindAsync(id);

            if (relationship == null)
            {
                return NotFound();
            }

            return Ok(relationship.ToRelationshipDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRelationshipRequestDto createRelationshipDto)
        {
            var relationshipModel = createRelationshipDto.ToRelationshipFromCreateDTO();
            await _context.Relationship.AddAsync(relationshipModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById),new { id= relationshipModel.RelationshipId}, relationshipModel.ToRelationshipDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRelationshipRequestDto updateRelationshipDto)
        {
            var relationshipModel =await _context.Relationship.FirstOrDefaultAsync(x => x.RelationshipId == id);
            if (relationshipModel == null) 
            {
                return NotFound();
            }
            var relationshipUpdateModel = updateRelationshipDto.ToRelationshipFromUpdateDTO();
            relationshipModel.Type = relationshipUpdateModel.Type;
            await _context.SaveChangesAsync();
            return Ok(relationshipModel.ToRelationshipDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var relationshipModel = _context.Relationship.FirstOrDefault(x => x.RelationshipId == id);
            if (relationshipModel == null) 
            {
                return NotFound();
            }
            _context.Relationship.Remove(relationshipModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}