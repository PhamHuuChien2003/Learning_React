using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentPic;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentContentPicRepository : ICommentContentPicRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentContentPicRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CommentContentPic> CreateAsync(CommentContentPic commentContentPicModel)
        {
            await _context.CommentContentPic.AddAsync(commentContentPicModel);
            await _context.SaveChangesAsync();
            return commentContentPicModel;
        }

        public async Task<CommentContentPic?> DeleteAsync(int id)
        {
            var commentContentPicModel = _context.CommentContentPic.FirstOrDefault(x => x.CommentContentPicID == id);
            if (commentContentPicModel == null) 
            {
                return null;
            }
            _context.CommentContentPic.Remove(commentContentPicModel);
            await _context.SaveChangesAsync();
            return commentContentPicModel;
        }

        public async Task<List<CommentContentPic>> GetAllAsync()
        {
            return await _context.CommentContentPic.ToListAsync();
        }

        public async Task<CommentContentPic?> GetByIdAsync(int id)
        {
            return await _context.CommentContentPic.FindAsync(id);
        }

        public async Task<CommentContentPic?> UpdateAsync(int id, UpdateCommentContentPicRequestDto commentContentPicDto)
        {
            var existingCommenrContentPic = await _context.CommentContentPic.FirstOrDefaultAsync(x => x.CommentContentPicID == id);
            if (existingCommenrContentPic == null)
            {
                return null;
            }

            var commentContentPicUpdateModel = commentContentPicDto.ToCommentContentPicFromUpdateDTO();
            existingCommenrContentPic.CommentContent = commentContentPicUpdateModel.CommentContent;
            existingCommenrContentPic.ImageURL= commentContentPicUpdateModel.ImageURL;
            await _context.SaveChangesAsync();
            return existingCommenrContentPic;

        }
    }
}