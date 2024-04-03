using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.RelationshipMember
{
    public class CreateRelationshipMemberRequestDto
    {
        public int? UserId { get; set; }
        public int? RelationshipId { get; set; }
    }
}