using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Relationship;
using api.Models;

namespace api.Interfaces
{
    public interface IRelationshipRepository
    {
        Task<List<Relationship>> GetAllAsync();
        Task<Relationship?> GetByIdAsync(int id);
        Task<Relationship> CreateAsync(Relationship relationshipModel);
        Task<Relationship?> UpdateAsync(int id , UpdateRelationshipRequestDto relationshipDto);
        Task<Relationship?> DeleteAsync(int id);
    }
}