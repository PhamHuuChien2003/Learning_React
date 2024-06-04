using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVote;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostDetailVoteRepository : IPostDetailVoteRepository
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVoteRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PostDetailVote> CreateAsync(PostDetailVote postDetailVoteModel)
        {
            await _context.PostDetailVote.AddAsync(postDetailVoteModel);
            await _context.SaveChangesAsync();
            return postDetailVoteModel;
        }

        public async Task<PostDetailVote?> DeleteAsync(int id)
        {
            var postDetailVoteModel = await _context.PostDetailVote.FirstOrDefaultAsync(x=>x.PostDetailVoteID == id);
            if (postDetailVoteModel == null )
            {
                return null;
            }
            _context.PostDetailVote.Remove(postDetailVoteModel);
            await _context.SaveChangesAsync();
            return postDetailVoteModel;
        }

        public async Task<List<PostDetailVote>> GetAllAsync()
        {
            return await _context.PostDetailVote.Include(c=>c.Votesections).ToListAsync();
        }

        public async Task<PostDetailVote?> GetByIdAsync(int id)
        {
            return await _context.PostDetailVote.FindAsync(id);
        }

        public async Task<PostDetailVote?> UpdateAsync(int id, UpdatePostDetailVoteRequestDto postDetailVoteDto)
        {
            var existingPostDetailVote = await _context.PostDetailVote.FirstOrDefaultAsync(x=>x.PostDetailVoteID == id);
            if(existingPostDetailVote == null)
            {
                return null;
            }
            var postDetailVoteUpdateModel = postDetailVoteDto.ToPostDetailVoteFromUpdateDTO();
            existingPostDetailVote.Content = postDetailVoteUpdateModel.Content;
            existingPostDetailVote.HashTag = postDetailVoteUpdateModel.HashTag;
            await _context.SaveChangesAsync();
            return existingPostDetailVote;
        }
    }
}