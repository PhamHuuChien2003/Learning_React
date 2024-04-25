using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Post;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDBContext _context;
        public PostRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Post> CreateAsync(Post postModel)
        {
            await _context.Post.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<Post?> DeleteAsync(int id)
        {
            var postModel = await _context.Post.FirstOrDefaultAsync(x=>x.PostId == id);
            if (postModel == null )
            {
                return null;
            }
            _context.Post.Remove(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _context.Post.ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Post.FindAsync(id);
        }

        public async Task<Post?> UpdateAsync(int id, UpdatePostRequestDto postDto)
        {
            var existingPost = await _context.Post.FirstOrDefaultAsync(x=>x.PostId == id);
            if(existingPost == null)
            {
                return null;
            }
            var postUpdateModel = postDto.ToPostFromUpdateDTO();
            existingPost.Type = postUpdateModel.Type;
            await _context.SaveChangesAsync();
            return existingPost;
        }
    }
}