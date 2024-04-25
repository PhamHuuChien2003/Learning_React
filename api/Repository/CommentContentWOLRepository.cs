using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.CommentContentWOL;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentContentWOLRepository : ICommentContentWOLRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentContentWOLRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CommentContentWOL> CreateAsync(CommentContentWOL commentContentWOLModel)
        {
            await _context.CommentContentWOL.AddAsync(commentContentWOLModel);
            await _context.SaveChangesAsync();
            return  commentContentWOLModel;
        }

        public async Task<CommentContentWOL?> DeleteAsync(int id)
        {
            var commentContentWOLModel = await _context.CommentContentWOL.FirstOrDefaultAsync(x=>x.CommentContentWOLID == id);
            if(commentContentWOLModel == null)
            {
                return null;
            }
            _context.CommentContentWOL.Remove(commentContentWOLModel);
            await _context.SaveChangesAsync();
            return commentContentWOLModel;
        }

        public async Task<List<CommentContentWOL>> GetAllAsync()
        {
            return await _context.CommentContentWOL.ToListAsync();
        }

        public async Task<CommentContentWOL?> GetByIdAsync(int id)
        {
            return await _context.CommentContentWOL.FindAsync(id);
        }

        public async Task<CommentContentWOL?> UpdateAsync(int id, UpdateCommentContentWOLRequestDto commentContentWOLDto)
        {
            var existingCommentContentWOL = await _context.CommentContentWOL.FirstOrDefaultAsync(x=>x.CommentContentWOLID == id);
            if(existingCommentContentWOL == null) 
            {
                return null;
            }
            var commentContentWOLUpdateModel = commentContentWOLDto.ToCommentContentWOLFromUpdateDTO();
            existingCommentContentWOL.CommentContent = commentContentWOLUpdateModel.CommentContent;
            await _context.SaveChangesAsync();
            return existingCommentContentWOL;
        }
    }
}