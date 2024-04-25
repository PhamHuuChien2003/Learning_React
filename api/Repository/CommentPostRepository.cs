using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentPost;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentPostRepository : ICommentPostRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentPostRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CommentPost> CreateAsync(CommentPost commentPostModel)
        {
            await _context.CommentPost.AddAsync(commentPostModel);
            await _context.SaveChangesAsync();
            return commentPostModel;
        }

        public async Task<CommentPost?> DeleteAsync(int id)
        {
            var commentPostModel = await _context.CommentPost.FirstOrDefaultAsync(x=>x.CommentPostID == id);
            if(commentPostModel == null)
            {
                return null;
            }
            _context.CommentPost.Remove(commentPostModel);
            await _context.SaveChangesAsync();
            return commentPostModel;
        }

        public async Task<List<CommentPost>> GetAllAsync()
        {
            return await _context.CommentPost.ToListAsync();
        }

        public async Task<CommentPost?> GetByIdAsync(int id)
        {
            return await _context.CommentPost.FindAsync(id);
        }

        public async Task<CommentPost?> UpdateAsync(int id, UpdateCommentPostRequestDto commentPostDto)
        {
            var existingCommentPost = await _context.CommentPost.FirstOrDefaultAsync(x=>x.CommentPostID ==id);
            if(existingCommentPost == null)
            {
                return null;
            }
            var commentPostUpdateModel = commentPostDto.ToCommentPostFromUpdateDTO();
            existingCommentPost.Type= commentPostUpdateModel.Type;
            await _context.SaveChangesAsync();
            return existingCommentPost;
        }
    }
}