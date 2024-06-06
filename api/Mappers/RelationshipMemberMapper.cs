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
                Messages = relationshipMemberModel.Messages.Select(c=>c.ToMessageDto()).ToList()
            };
        }
        public static RelationshipMember ToRelationshipMemberFromCreateDTO(this CreateRelationshipMemberRequestDto relationshipMemberDto)
        {
            return new RelationshipMember
            {
                UserId = relationshipMemberDto.UserId,
                RelationshipId = relationshipMemberDto.RelationshipId,
                // Messages = relationshipMemberDto.Messages.Select(c=>c.ToMessageFromCreateDTO()).ToList()
            };
        }
        public static RelationshipMember ToRelationshipMemberFromUpdateDTO(this UpdateRelationshipMemberRequestDto relationshipMemberUpdateDto)
        {
            return new RelationshipMember
            {
                UserId = relationshipMemberUpdateDto.UserId,
                RelationshipId = relationshipMemberUpdateDto.RelationshipId,
                // Messages = relationshipMemberUpdateDto.Messages.Select(c=>c.ToMessageFromUpdateDTO()).ToList()
            };
        }
    }
}