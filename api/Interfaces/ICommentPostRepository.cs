using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentPost;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentPostRepository
    {
        Task<List<CommentPost>> GetAllAsync();
        Task<CommentPost?> GetByIdAsync(int id);
        Task<CommentPost> CreateAsync(CommentPost commentPostModel);
        Task<CommentPost?> UpdateAsync(int id , UpdateCommentPostRequestDto commentPostDto);
        Task<CommentPost?> DeleteAsync(int id);
    }
}