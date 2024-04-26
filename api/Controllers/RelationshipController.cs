using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Relationship;
using api.Interfaces;
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
        private readonly IRelationshipRepository _relationshipRepo;
        public RelationshipController(ApplicationDBContext context, IRelationshipRepository relationshipRepo)
        {
            _context = context;
            _relationshipRepo =relationshipRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relationship =await _relationshipRepo.GetAllAsync();
            var relationshipDto = relationship.Select(s => s.ToRelationshipDto());

            return Ok(relationship);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var relationship =await _relationshipRepo.GetByIdAsync(id);

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
            await _relationshipRepo.CreateAsync(relationshipModel);
            return CreatedAtAction(nameof(GetById),new { id= relationshipModel.RelationshipId}, relationshipModel.ToRelationshipDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRelationshipRequestDto updateRelationshipDto)
        {
            var relationshipModel =await _relationshipRepo.UpdateAsync(id, updateRelationshipDto);
            if (relationshipModel == null) 
            {
                return NotFound();
            }
            return Ok(relationshipModel.ToRelationshipDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var relationshipModel = _relationshipRepo.DeleteAsync(id);
            if (relationshipModel == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}