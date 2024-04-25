using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentContentVideo;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentContentVideoRepository
    {
        Task<List<CommentContentVideo>> GetAllAsync();
        Task<CommentContentVideo?> GetByIdAsync(int id);
        Task<CommentContentVideo> CreateAsync(CommentContentVideo commentContentVideoModel);
        Task<CommentContentVideo?> UpdateAsync(int id , UpdateCommentContentVideoRequestDto commentContentVideoDto);
        Task<CommentContentVideo?> DeleteAsync(int id);
    }
}