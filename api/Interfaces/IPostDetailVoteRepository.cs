using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailVote;
using api.Models;

namespace api.Interfaces
{
    public interface IPostDetailVoteRepository
    {
        Task<List<PostDetailVote>> GetAllAsync();
        Task<PostDetailVote?> GetByIdAsync(int id);
        Task<PostDetailVote> CreateAsync(PostDetailVote postDetailVoteModel);
        Task<PostDetailVote?> UpdateAsync(int id , UpdatePostDetailVoteRequestDto postDetailVoteDto);
        Task<PostDetailVote?> DeleteAsync(int id);
    }
}