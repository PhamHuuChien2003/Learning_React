using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailWOL;
using api.Models;

namespace api.Interfaces
{
    public interface IPostDetailWOLRepository
    {
        Task<List<PostDetailWOL>> GetAllAsync();
        Task<PostDetailWOL?> GetByIdAsync(int id);
        Task<PostDetailWOL> CreateAsync(PostDetailWOL postDetailWOLModel);
        Task<PostDetailWOL?> UpdateAsync(int id , UpdatePostDetailWOLRequestDto postDetailWOLDto);
        Task<PostDetailWOL?> DeleteAsync(int id);
    }
}