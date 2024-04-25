using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.ReactPost;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReactPostRepository : IReactPostRepository
    {
        private readonly ApplicationDBContext _context;
        public ReactPostRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ReactPost> CreateAsync(ReactPost reactPostModel)
        {
            await _context.ReactPost.AddAsync(reactPostModel);
            await _context.SaveChangesAsync();
            return reactPostModel;
        }

        public async Task<ReactPost?> DeleteAsync(int id)
        {
            var reactPostModel = await _context.ReactPost.FirstOrDefaultAsync(x=>x.ReactPostID == id);
            if (reactPostModel == null )
            {
                return null;
            }
            _context.ReactPost.Remove(reactPostModel);
            await _context.SaveChangesAsync();
            return reactPostModel;
        }

        public async Task<List<ReactPost>> GetAllAsync()
        {
            return await _context.ReactPost.ToListAsync();
        }

        public async Task<ReactPost?> GetByIdAsync(int id)
        {
            return await _context.ReactPost.FindAsync(id);
        }

        public async Task<ReactPost?> UpdateAsync(int id, UpdateReactPostRequestDto reactPostDto)
        {
            var existingReactPost = await _context.ReactPost.FirstOrDefaultAsync(x=>x.ReactPostID == id);
            if(existingReactPost == null)
            {
                return null;
            }
            var reactPostUpdateModel = reactPostDto.ToReactPostFromUpdateDTO();
            existingReactPost.Type = reactPostUpdateModel.Type;
            await _context.SaveChangesAsync();
            return existingReactPost;
        }
    }
}