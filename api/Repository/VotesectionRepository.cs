using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Votesection;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VotesectionRepository : IVotesectionRepository
    {
        private readonly ApplicationDBContext _context;
        public VotesectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Votesection> CreateAsync(Votesection votesectionModel)
        {
            await _context.Votesection.AddAsync(votesectionModel);
            await _context.SaveChangesAsync();
            return votesectionModel;
        }

        public async Task<Votesection?> DeleteAsync(int id)
        {
            var votesectionModel = await _context.Votesection.FirstOrDefaultAsync(x=>x.VotesectionID == id);
            if (votesectionModel == null )
            {
                return null;
            }
            _context.Votesection.Remove(votesectionModel);
            await _context.SaveChangesAsync();
            return votesectionModel;
        }

        public async Task<List<Votesection>> GetAllAsync()
        {
            return await _context.Votesection.ToListAsync();
        }

        public async Task<Votesection?> GetByIdAsync(int id)
        {
            return await _context.Votesection.FindAsync(id);
        }

        public async Task<Votesection?> UpdateAsync(int id, UpdateVoteSectionRequestDto votesectionDto)
        {
            var existingVotesection = await _context.Votesection.FirstOrDefaultAsync(x=>x.VotesectionID == id);
            if(existingVotesection == null)
            {
                return null;
            }
            var votesectionUpdateModel = votesectionDto.ToVoteSectionFromUpdateDTO();
            existingVotesection.VoteName = votesectionUpdateModel.VoteName;
            await _context.SaveChangesAsync();
            return existingVotesection;
        }
    }
}