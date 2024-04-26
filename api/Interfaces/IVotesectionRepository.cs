using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Votesection;
using api.Models;

namespace api.Interfaces
{
    public interface IVotesectionRepository
    {
        Task<List<Votesection>> GetAllAsync();
        Task<Votesection?> GetByIdAsync(int id);
        Task<Votesection> CreateAsync(Votesection votesectionModel);
        Task<Votesection?> UpdateAsync(int id , UpdateVoteSectionRequestDto votesectionDto);
        Task<Votesection?> DeleteAsync(int id);
    }
}