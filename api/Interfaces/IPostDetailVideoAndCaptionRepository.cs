using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailVideoAndCaption;
using api.Models;

namespace api.Interfaces
{
    public interface IPostDetailVideoAndCaptionRepository
    {
        Task<List<PostDetailVideoAndCaption>> GetAllAsync();
        Task<PostDetailVideoAndCaption?> GetByIdAsync(int id);
        Task<PostDetailVideoAndCaption> CreateAsync(PostDetailVideoAndCaption postDetailVideoAndCaptionModel);
        Task<PostDetailVideoAndCaption?> UpdateAsync(int id , UpdatePostDetailVideoAndCaptionRequestDto postDetailVideoAndCaptionDto);
        Task<PostDetailVideoAndCaption?> DeleteAsync(int id);
    }
}