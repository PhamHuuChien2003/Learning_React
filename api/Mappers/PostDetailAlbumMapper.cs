using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailAlbum;
using api.Models;

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
    }
}