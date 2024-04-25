using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.PostDetailAlbum;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PostDetailAlbumRepository : IPostDetailAlbumRepository
    {
        private readonly ApplicationDBContext _context;
        public PostDetailAlbumRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PostDetailAlbum> CreateAsync(PostDetailAlbum postDetailAlbumModel)
        {
            await _context.PostDetailAlbum.AddAsync(postDetailAlbumModel);
            await _context.SaveChangesAsync();
            return postDetailAlbumModel;
        }

        public async Task<PostDetailAlbum?> DeleteAsync(int id)
        {
            var postDetailAlbumModel = await _context.PostDetailAlbum.FirstOrDefaultAsync(x=>x.PostDetailAlbumID == id);
            if (postDetailAlbumModel == null )
            {
                return null;
            }
            _context.PostDetailAlbum.Remove(postDetailAlbumModel);
            await _context.SaveChangesAsync();
            return postDetailAlbumModel;
        }

        public async Task<List<PostDetailAlbum>> GetAllAsync()
        {
            return await _context.PostDetailAlbum.ToListAsync();
        }

        public async Task<PostDetailAlbum?> GetByIdAsync(int id)
        {
            return await _context.PostDetailAlbum.FindAsync(id);
        }

        public async Task<PostDetailAlbum?> UpdateAsync(int id, UpdatePostDetailAlbumRequestDto postDetailAlbumDto)
        {
            var existingPostDetailAlbum = await _context.PostDetailAlbum.FirstOrDefaultAsync(x=>x.PostDetailAlbumID == id);
            if(existingPostDetailAlbum == null)
            {
                return null;
            }
            var postDetailAlbumUpdateModel = postDetailAlbumDto.ToPostDetailAlbumFromUpdateDTO();
            existingPostDetailAlbum.Content = postDetailAlbumUpdateModel.Content;
            existingPostDetailAlbum.HashTag = postDetailAlbumUpdateModel.HashTag;
            existingPostDetailAlbum.AlbumURL = postDetailAlbumUpdateModel.AlbumURL;
            await _context.SaveChangesAsync();
            return existingPostDetailAlbum;
        }
    }
}