using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentVideo;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentContentVideoRepository : ICommentContentVideoRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentContentVideoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CommentContentVideo> CreateAsync(CommentContentVideo commentContentVideoModel)
        {
            await _context.CommentContentVideo.AddAsync(commentContentVideoModel);
            await _context.SaveChangesAsync();
            return commentContentVideoModel;
        }

        public async Task<CommentContentVideo?> DeleteAsync(int id)
        {
            var commentContentVideoModel = await _context.CommentContentVideo.FirstOrDefaultAsync(x=>x.CommentContentVideoID == id);
            if(commentContentVideoModel == null)
            {
                return null;
            }
            _context.CommentContentVideo.Remove(commentContentVideoModel);
            await _context.SaveChangesAsync();
            return commentContentVideoModel;
        }

        public async Task<List<CommentContentVideo>> GetAllAsync()
        {
            return await _context.CommentContentVideo.ToListAsync();
        }

        public async Task<CommentContentVideo?> GetByIdAsync(int id)
        {
            return await _context.CommentContentVideo.FindAsync(id);
        }

        public async Task<CommentContentVideo?> UpdateAsync(int id, UpdateCommentContentVideoRequestDto commentContentVideoDto)
        {
            var existingCommentContentVideo = await _context.CommentContentVideo.FirstOrDefaultAsync(x=>x.CommentContentVideoID==id);
            if(existingCommentContentVideo == null)
            {
                return null;
            }
            var commentContentVideoUpdateModel = commentContentVideoDto.ToCommentContentVideoFromUpdateDTO();
            existingCommentContentVideo.CommentContent = commentContentVideoUpdateModel.CommentContent;
            existingCommentContentVideo.VideoURL = commentContentVideoUpdateModel.VideoURL;
            await _context.SaveChangesAsync();
            return existingCommentContentVideo;
        }
    }
}