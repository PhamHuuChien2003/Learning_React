using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailWOL;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostDetailWOLRepository : IPostDetailWOLRepository
    {
        private readonly ApplicationDBContext _context;
        public PostDetailWOLRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PostDetailWOL> CreateAsync(PostDetailWOL postDetailWOLModel)
        {
            await _context.PostDetailWOL.AddAsync(postDetailWOLModel);
            await _context.SaveChangesAsync();
            return postDetailWOLModel;
        }

        public async Task<PostDetailWOL?> DeleteAsync(int id)
        {
            var postDetailWOLModel = await _context.PostDetailWOL.FirstOrDefaultAsync(x=>x.PostDetailWOLID == id);
            if (postDetailWOLModel == null )
            {
                return null;
            }
            _context.PostDetailWOL.Remove(postDetailWOLModel);
            await _context.SaveChangesAsync();
            return postDetailWOLModel;
        }

        public async Task<List<PostDetailWOL>> GetAllAsync()
        {
            return await _context.PostDetailWOL.ToListAsync();
        }

        public async Task<PostDetailWOL?> GetByIdAsync(int id)
        {
            return await _context.PostDetailWOL.FindAsync(id);
        }

        public async Task<PostDetailWOL?> UpdateAsync(int id, UpdatePostDetailWOLRequestDto postDetailWOLDto)
        {
            var existingPostDetailWOL = await _context.PostDetailWOL.FirstOrDefaultAsync(x=>x.PostDetailWOLID == id);
            if(existingPostDetailWOL == null)
            {
                return null;
            }
            var postDetailWOLUpdateModel = postDetailWOLDto.ToPostDetailWOLFromUpdateDTO();
            existingPostDetailWOL.Content = postDetailWOLUpdateModel.Content;
            existingPostDetailWOL.HashTag = postDetailWOLUpdateModel.HashTag;
            await _context.SaveChangesAsync();
            return existingPostDetailWOL;
        }
    }
}