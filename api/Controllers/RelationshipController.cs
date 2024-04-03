using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Relationship;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var relationship = _context.Relationship.ToList()
                .Select(s => s.ToRelationshipDto());

            return Ok(relationship);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var relationship = _context.Relationship.Find(id);

            if (relationship == null)
            {
                return NotFound();
            }

            return Ok(relationship.ToRelationshipDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateRelationshipRequestDto createRelationshipDto)
        {
            var relationshipModel = createRelationshipDto.ToRelationshipFromCreateDTO();
            _context.Relationship.Add(relationshipModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= relationshipModel.RelationshipId}, relationshipModel.ToRelationshipDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateRelationshipRequestDto updateRelationshipDto)
        {
            var relationshipModel = _context.Relationship.FirstOrDefault(x => x.RelationshipId == id);
            if (relationshipModel == null) 
            {
                return NotFound();
            }
            relationshipModel = updateRelationshipDto.ToRelationshipFromUpdateDTO();
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),new { id= relationshipModel.RelationshipId}, relationshipModel.ToRelationshipDto());
        }
    }
}