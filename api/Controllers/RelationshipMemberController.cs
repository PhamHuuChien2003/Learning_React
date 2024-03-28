using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var relationshipMember = _context.RelationshipMember.ToList();

            return Ok(relationshipMember);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var relationshipMember = _context.RelationshipMember.Find(id);

            if (relationshipMember == null)
            {
                return NotFound();
            }

            return Ok(relationshipMember);
        }
    }
}