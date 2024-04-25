using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailVideoAndCaption;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostDetailVideoAndCaptionRepository : IPostDetailVideoAndCaptionRepository
    {
        private readonly ApplicationDBContext _context;
        public PostDetailVideoAndCaptionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PostDetailVideoAndCaption> CreateAsync(PostDetailVideoAndCaption postDetailVideoAndCaptionModel)
        {
            await _context.PostDetailVideoAndCaption.AddAsync(postDetailVideoAndCaptionModel);
            await _context.SaveChangesAsync();
            return postDetailVideoAndCaptionModel;
        }

        public async Task<PostDetailVideoAndCaption?> DeleteAsync(int id)
        {
            var postDetailVideoAndCaptionModel = await _context.PostDetailVideoAndCaption.FirstOrDefaultAsync(x=>x.PostDetailVideoAndCaptionID == id);
            if (postDetailVideoAndCaptionModel == null )
            {
                return null;
            }
            _context.PostDetailVideoAndCaption.Remove(postDetailVideoAndCaptionModel);
            await _context.SaveChangesAsync();
            return postDetailVideoAndCaptionModel;
        }

        public async Task<List<PostDetailVideoAndCaption>> GetAllAsync()
        {
            return await _context.PostDetailVideoAndCaption.ToListAsync();
        }

        public async Task<PostDetailVideoAndCaption?> GetByIdAsync(int id)
        {
            return await _context.PostDetailVideoAndCaption.FindAsync(id);
        }

        public async Task<PostDetailVideoAndCaption?> UpdateAsync(int id, UpdatePostDetailVideoAndCaptionRequestDto postDetailVideoAndCaptionDto)
        {
            var existingPostDetailVideoAndCaption = await _context.PostDetailVideoAndCaption.FirstOrDefaultAsync(x=>x.PostDetailVideoAndCaptionID == id);
            if(existingPostDetailVideoAndCaption == null)
            {
                return null;
            }
            var postDetailVideoAndCaptionUpdateModel = postDetailVideoAndCaptionDto.ToPostDetailVideoAndCaptionFromUpdateDTO();
            existingPostDetailVideoAndCaption.Content = postDetailVideoAndCaptionUpdateModel.Content;
            existingPostDetailVideoAndCaption.HashTag = postDetailVideoAndCaptionUpdateModel.HashTag;
            existingPostDetailVideoAndCaption.VideoURL = postDetailVideoAndCaptionUpdateModel.VideoURL;
            await _context.SaveChangesAsync();

            return existingPostDetailVideoAndCaption;
        }
    }
}