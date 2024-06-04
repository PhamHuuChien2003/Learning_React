using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Relationship;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RelationshipRepository : IRelationshipRepository
    {
        private readonly ApplicationDBContext _context;
        public RelationshipRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Relationship> CreateAsync(Relationship relationshipModel)
        {
            await _context.Relationship.AddAsync(relationshipModel);
            await _context.SaveChangesAsync();
            return relationshipModel;
        }

        public async Task<Relationship?> DeleteAsync(int id)
        {
            var relationshipModel = await _context.Relationship.FirstOrDefaultAsync(x=>x.RelationshipId == id);
            if (relationshipModel == null )
            {
                return null;
            }
            _context.Relationship.Remove(relationshipModel);
            await _context.SaveChangesAsync();
            return relationshipModel;
        }

        public async Task<List<Relationship>> GetAllAsync()
        {
            return await _context.Relationship.Include(c=>c.RelationshipMembers).ToListAsync();
        }

        public async Task<Relationship?> GetByIdAsync(int id)
        {
            return await _context.Relationship.Include(c=>c.RelationshipMembers).FirstOrDefaultAsync(i=>i.RelationshipId==id);
        }

        public async Task<Relationship?> UpdateAsync(int id, UpdateRelationshipRequestDto relationshipDto)
        {
            var existingRelationship = await _context.Relationship.FirstOrDefaultAsync(x=>x.RelationshipId == id);
            if(existingRelationship == null)
            {
                return null;
            }
            var relationshipUpdateModel = relationshipDto.ToRelationshipFromUpdateDTO();
            existingRelationship.Type = relationshipUpdateModel.Type;
            await _context.SaveChangesAsync();
            return existingRelationship;
        }
    }
}