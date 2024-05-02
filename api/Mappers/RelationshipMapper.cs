using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Relationship;
using api.Models;

namespace api.Mappers
{
    public static  class RelationshipMapper
    {
        public static RelationshipDto ToRelationshipDto(this Relationship relationshipModel)
        {
            return new RelationshipDto
            {
                RelationshipId = relationshipModel.RelationshipId,
                StartTime = relationshipModel.StartTime,
                Type = relationshipModel.Type,
                RelationshipMembers = relationshipModel.RelationshipMembers.Select(c => c.ToRelationshipMemberDto()).ToList()

            };
        }
        public static Relationship ToRelationshipFromCreateDTO(this CreateRelationshipRequestDto createRelationshipDto)
        {
            return new Relationship
            {
                StartTime = createRelationshipDto.StartTime,
                Type = createRelationshipDto.Type,
                RelationshipMembers = createRelationshipDto.RelationshipMembers.Select(c => c.ToRelationshipMemberFromCreateDTO()).ToList()
            };
        }
        public static Relationship ToRelationshipFromUpdateDTO(this UpdateRelationshipRequestDto createRelationshipUpdateDto)
        {
            return new Relationship
            {
                StartTime = createRelationshipUpdateDto.StartTime,
                Type = createRelationshipUpdateDto.Type,
                RelationshipMembers = createRelationshipUpdateDto.RelationshipMembers.Select(c => c.ToRelationshipMemberFromUpdateDTO()).ToList()
            };
        }
    }
}