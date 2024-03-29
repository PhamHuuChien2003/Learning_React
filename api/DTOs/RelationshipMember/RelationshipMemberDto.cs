using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.RelationshipMember
{
    public class RelationshipMemberDto
    {
        public int RelationshipMemberId { get; set; }
        public int? UserId { get; set; }
        public int? RelationshipId { get; set; }
    }
}