using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.RelationshipMember;
using api.Models;

namespace api.Mappers
{
    public static class RelationshipMemberMapper
    {
        public static RelationshipMemberDto ToRelationshipMemberDto(this RelationshipMember relationshipMemberModel)
        {
            return new RelationshipMemberDto
            {
                RelationshipMemberId = relationshipMemberModel.RelationshipMemberId,
                UserId = relationshipMemberModel.UserId,
                RelationshipId = relationshipMemberModel.RelationshipId,
            };
        }
    }
}