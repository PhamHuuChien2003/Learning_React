using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentContentPic;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentContentPicRepository
    {
        Task<List<CommentContentPic>> GetAllAsync();
        Task<CommentContentPic?> GetByIdAsync(int id);
        Task<CommentContentPic> CreateAsync(CommentContentPic commentContentPicModel);
        Task<CommentContentPic?> UpdateAsync(int id , UpdateCommentContentPicRequestDto commentContentPicDto);
        Task<CommentContentPic?> DeleteAsync(int id);
    }
}