using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailSGPicWithCaption;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostDetailSGPicWithCaptionRepository : IPostDetailSGPicWithCaptionRepository
    {
        private readonly ApplicationDBContext _context;
        public PostDetailSGPicWithCaptionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PostDetailSGPicWithCaption> CreateAsync(PostDetailSGPicWithCaption postDetailSGPicWithCaptionModel)
        {
            await _context.PostDetailSGPicWithCaption.AddAsync(postDetailSGPicWithCaptionModel);
            await _context.SaveChangesAsync();
            return postDetailSGPicWithCaptionModel;
        }

        public async Task<PostDetailSGPicWithCaption?> DeleteAsync(int id)
        {
            var postDetailSGPicWithCaptionModel = await _context.PostDetailSGPicWithCaption.FirstOrDefaultAsync(x=>x.PostDetailSGPicWithCaptionID == id);
            if (postDetailSGPicWithCaptionModel == null )
            {
                return null;
            }
            _context.PostDetailSGPicWithCaption.Remove(postDetailSGPicWithCaptionModel);
            await _context.SaveChangesAsync();
            return postDetailSGPicWithCaptionModel;
        }

        public async Task<List<PostDetailSGPicWithCaption>> GetAllAsync()
        {
            return await _context.PostDetailSGPicWithCaption.ToListAsync();
        }

        public async Task<PostDetailSGPicWithCaption?> GetByIdAsync(int id)
        {
            return await _context.PostDetailSGPicWithCaption.FindAsync(id);
        }

        public async Task<PostDetailSGPicWithCaption?> UpdateAsync(int id, UpdatePostDetailSGPicWithCaptionRequestDto postDetailSGPicWithCaptionDto)
        {
            var existingPostDetailSGPicWithCaption = await _context.PostDetailSGPicWithCaption.FirstOrDefaultAsync(x=>x.PostDetailSGPicWithCaptionID == id);
            if(existingPostDetailSGPicWithCaption == null)
            {
                return null;
            }
            var postDetailSGPicWithCaptionUpdateModel = postDetailSGPicWithCaptionDto.ToPostDetailSGPicWithCaptionFromUpdateDTO();
            existingPostDetailSGPicWithCaption.Content = postDetailSGPicWithCaptionUpdateModel.Content;
            existingPostDetailSGPicWithCaption.HashTag = postDetailSGPicWithCaptionUpdateModel.HashTag;
            existingPostDetailSGPicWithCaption.ImageURL = postDetailSGPicWithCaptionUpdateModel.ImageURL;
            await _context.SaveChangesAsync();
            return existingPostDetailSGPicWithCaption;
        }
    }
}