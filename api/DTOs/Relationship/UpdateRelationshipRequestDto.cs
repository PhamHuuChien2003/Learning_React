using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.RelationshipMember;

namespace api.DTOs.Relationship
{
    public class UpdateRelationshipRequestDto
    {
        public DateTime StartTime { get; set;} = DateTime.Now ;
        public string Type { get; set; } = string.Empty;
        public List<UpdateRelationshipMemberRequestDto>? RelationshipMembers { get; set; }
    }
}