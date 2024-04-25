using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailSGPicWithCaption;
using api.Models;

namespace api.Interfaces
{
    public interface IPostDetailSGPicWithCaptionRepository
    {
        Task<List<PostDetailSGPicWithCaption>> GetAllAsync();
        Task<PostDetailSGPicWithCaption?> GetByIdAsync(int id);
        Task<PostDetailSGPicWithCaption> CreateAsync(PostDetailSGPicWithCaption postDetailSGPicWithCaptionModel);
        Task<PostDetailSGPicWithCaption?> UpdateAsync(int id , UpdatePostDetailSGPicWithCaptionRequestDto postDetailSGPicWithCaptionDto);
        Task<PostDetailSGPicWithCaption?> DeleteAsync(int id);
    }
}