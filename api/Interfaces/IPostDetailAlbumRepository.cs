using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailAlbum;
using api.Models;

namespace api.Interfaces
{
    public interface IPostDetailAlbumRepository
    {
        Task<List<PostDetailAlbum>> GetAllAsync();
        Task<PostDetailAlbum?> GetByIdAsync(int id);
        Task<PostDetailAlbum> CreateAsync(PostDetailAlbum postDetailAlbumModel);
        Task<PostDetailAlbum?> UpdateAsync(int id , UpdatePostDetailAlbumRequestDto postDetailAlbumDto);
        Task<PostDetailAlbum?> DeleteAsync(int id);
    }
}