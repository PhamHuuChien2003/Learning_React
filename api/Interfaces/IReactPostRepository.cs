using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.ReactPost;
using api.Models;

namespace api.Interfaces
{
    public interface IReactPostRepository
    {
        Task<List<ReactPost>> GetAllAsync();
        Task<ReactPost?> GetByIdAsync(int id);
        Task<ReactPost> CreateAsync(ReactPost reactPostModel);
        Task<ReactPost?> UpdateAsync(int id , UpdateReactPostRequestDto reactPostDto);
        Task<ReactPost?> DeleteAsync(int id);
    }
}