using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Post;
using api.Models;

namespace api.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                PostId = postModel.PostId,
                Type = postModel.Type,
                Posttime = postModel.Posttime,
                UserId = postModel.UserId
            };
        }
    }
}