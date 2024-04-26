using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.VoteResult;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VoteResultRepository : IVoteResultRepository
    {
        private readonly ApplicationDBContext _context;
        public VoteResultRepository(ApplicationDBContext context)
        {
            _context = context ;
        }
        public async Task<VoteResult> CreateAsync(VoteResult voteResultModel)
        {
            await _context.VoteResult.AddAsync(voteResultModel);
            await _context.SaveChangesAsync();
            return voteResultModel;
        }

        public async Task<VoteResult?> DeleteAsync(int id)
        {
            var voteResultModel = await _context.VoteResult.FirstOrDefaultAsync(x=>x.VoteResultID == id);
            if (voteResultModel == null )
            {
                return null;
            }
            _context.VoteResult.Remove(voteResultModel);
            await _context.SaveChangesAsync();
            return voteResultModel;
        }

        public async Task<List<VoteResult>> GetAllAsync()
        {
            return await _context.VoteResult.ToListAsync();
        }

        public async Task<VoteResult?> GetByIdAsync(int id)
        {
            return await _context.VoteResult.FindAsync(id);
        }

        public async Task<VoteResult?> UpdateAsync(int id, UpdateVoteResultRequestDto voteResultDto)
        {
            var existingVoteResult = await _context.VoteResult.FirstOrDefaultAsync(x=>x.VoteResultID == id);
            if(existingVoteResult == null)
            {
                return null;
            }
            
            return existingVoteResult;
        }
    }
}