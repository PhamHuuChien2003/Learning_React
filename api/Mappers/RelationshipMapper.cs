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
            };
        }
    }
}