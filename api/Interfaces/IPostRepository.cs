using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Post;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllAsync(PostQueryObject postQuery);
        Task<Post?> GetByIdAsync(int id);
        Task<Post> CreateAsync(Post postModel);
        Task<Post?> UpdateAsync(int id, UpdatePostRequestDto postDto);
        Task<Post?> DeleteAsync(int id);
    }
}