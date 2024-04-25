using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentContentWOL;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentContentWOLRepository
    {
        Task<List<CommentContentWOL>> GetAllAsync();
        Task<CommentContentWOL?> GetByIdAsync(int id);
        Task<CommentContentWOL> CreateAsync(CommentContentWOL commentContentWOLModel);
        Task<CommentContentWOL?> UpdateAsync(int id , UpdateCommentContentWOLRequestDto commentContentWOLDto);
        Task<CommentContentWOL?> DeleteAsync(int id);
    }
}