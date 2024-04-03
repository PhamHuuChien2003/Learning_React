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
        public static ReactPost ToReactPostFromCreateDTO(this CreateReactPostRequestDto reactPostDto)
        {
            return new ReactPost
            {
                PostID = reactPostDto.PostID,
                Type = reactPostDto.Type,
                UserID = reactPostDto.UserID,
            };
        }
        public static ReactPost ToReactPostFromUpdateDTO(this UpdateReactPostRequestDto reactPostUpdateDto)
        {
            return new ReactPost
            {
                PostID = reactPostUpdateDto.PostID,
                Type = reactPostUpdateDto.Type,
                UserID = reactPostUpdateDto.UserID,
            };
        }
    }
}