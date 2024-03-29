using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.ReactPost;
using api.Models;

namespace api.Mappers
{
    public static class ReactPostMapper
    {
        public static ReactPostDto ToReactPostDto(this ReactPost reactPostModel)
        {
            return new ReactPostDto
            {
                ReactPostID = reactPostModel.ReactPostID,
                PostID = reactPostModel.PostID,
                Type = reactPostModel.Type,
                UserID = reactPostModel.UserID,
            };
        }
    }
}