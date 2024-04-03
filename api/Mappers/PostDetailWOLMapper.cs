using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailWOL;
using api.Models;

namespace api.Mappers
{
    public static class PostDetailWOLMapper
    {
        public static PostDetailWOLDto ToPostDetailWOLDto(this PostDetailWOL postDetailWOLModle)
        {
            return new PostDetailWOLDto
            {
                PostDetailWOLID = postDetailWOLModle.PostDetailWOLID,
                PostID = postDetailWOLModle.PostID,
                Content = postDetailWOLModle.Content,
                HashTag = postDetailWOLModle.HashTag,
            };
        }
        public static PostDetailWOL ToPostDetailWOLDTO(this CreatePostDetailWOLRequestDto postDetailWOLDto)
        {
            return new PostDetailWOL
            {
                PostID = postDetailWOLDto.PostID,
                Content = postDetailWOLDto.Content,
                HashTag = postDetailWOLDto.HashTag,
            };
        }
    }
}