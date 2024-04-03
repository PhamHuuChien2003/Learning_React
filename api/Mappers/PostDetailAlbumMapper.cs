using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailAlbum;
using api.Models;
using Microsoft.Identity.Client;

namespace api.Mappers
{
    public static class PostDetailAlbumMapper
    {
        public static PostDetailAlbumDto ToPostDetailAlbumDto(this PostDetailAlbum postDetailAlbumModel)
        {
            return new PostDetailAlbumDto
            {
                PostDetailAlbumID = postDetailAlbumModel.PostDetailAlbumID,
                PostID = postDetailAlbumModel.PostID,
                Content = postDetailAlbumModel.Content,
                HashTag = postDetailAlbumModel.HashTag,
                AlbumURL = postDetailAlbumModel.AlbumURL,
            };
        }
        public static PostDetailAlbum ToPostDetailAlbumFromCreateDTO(this CreatePostDetailAlbumRequestDto postDetailAlbumDto)
        {
            return new PostDetailAlbum
            {
                PostID = postDetailAlbumDto.PostID,
                Content = postDetailAlbumDto.Content,
                HashTag = postDetailAlbumDto.HashTag,
                AlbumURL = postDetailAlbumDto.AlbumURL,
            };
        }
    }
}