using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.RelationshipMember;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RelationshipMemberRepository : IRelationshipMemberRepository
    {
        private readonly ApplicationDBContext _context;
        public RelationshipMemberRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<RelationshipMember> CreateAsync(RelationshipMember relationshipMemberModel)
        {
            await _context.RelationshipMember.AddAsync(relationshipMemberModel);
            await _context.SaveChangesAsync();
            return relationshipMemberModel;
        }

        public async Task<RelationshipMember?> DeleteAsync(int id)
        {
            var relationshipMemberModel = await _context.RelationshipMember.FirstOrDefaultAsync(x=>x.RelationshipMemberId == id);
            if (relationshipMemberModel == null )
            {
                return null;
            }
            _context.RelationshipMember.Remove(relationshipMemberModel);
            await _context.SaveChangesAsync();
            return relationshipMemberModel;
        }

        public async Task<List<RelationshipMember>> GetAllAsync()
        {
            return await _context.RelationshipMember.ToListAsync();
        }

        public async Task<RelationshipMember?> GetByIdAsync(int id)
        {
            return await _context.RelationshipMember.FindAsync(id);
        }

        public async Task<RelationshipMember?> UpdateAsync(int id, UpdateRelationshipMemberRequestDto relationshipMemberDto)
        {
            var existingRelationshipMember = await _context.RelationshipMember.FirstOrDefaultAsync(x=>x.RelationshipMemberId == id);
            if(existingRelationshipMember == null)
            {
                return null;
            }
            var relationshipMemberUpdateModel = relationshipMemberDto.ToRelationshipMemberFromUpdateDTO();
            existingRelationshipMember.UserId = relationshipMemberUpdateModel.UserId;
            existingRelationshipMember.RelationshipId = relationshipMemberUpdateModel.RelationshipId;
            await _context.SaveChangesAsync();

            return existingRelationshipMember;
        }
    }
}