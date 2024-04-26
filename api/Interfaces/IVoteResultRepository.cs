using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.VoteResult;
using api.Models;

namespace api.Interfaces
{
    public interface IVoteResultRepository
    {
        Task<List<VoteResult>> GetAllAsync();
        Task<VoteResult?> GetByIdAsync(int id);
        Task<VoteResult> CreateAsync(VoteResult voteResultModel);
        Task<VoteResult?> UpdateAsync(int id , UpdateVoteResultRequestDto voteResultDto);
        Task<VoteResult?> DeleteAsync(int id);
    }
}