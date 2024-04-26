using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.RelationshipMember;
using api.Models;

namespace api.Interfaces
{
    public interface IRelationshipMemberRepository
    {
        Task<List<RelationshipMember>> GetAllAsync();
        Task<RelationshipMember?> GetByIdAsync(int id);
        Task<RelationshipMember> CreateAsync(RelationshipMember relationshipMemberModel);
        Task<RelationshipMember?> UpdateAsync(int id , UpdateRelationshipMemberRequestDto relationshipMemberDto);
        Task<RelationshipMember?> DeleteAsync(int id);
    }
}