using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
    }
}