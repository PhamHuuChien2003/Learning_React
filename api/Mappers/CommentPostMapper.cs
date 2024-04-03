using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentPost;
using api.Models;

namespace api.Mappers
{
    public static class CommentPostMapper
    {
        public static CommentPostDto ToCommentPostDto(this CommentPost commentPostModel)
        {
            return new CommentPostDto
            {
                CommentPostID = commentPostModel.CommentPostID,
                PostId = commentPostModel.PostId,
                Type = commentPostModel.Type,
                UserID = commentPostModel.UserID,
            };
        }
        public static CommentPost ToCommentPostFromCreateDTO(this CreateCommentPostRequestDto commentPostDto)
        {
            return new CommentPost
            {
                PostId = commentPostDto.PostId,
                Type = commentPostDto.Type,
                UserID = commentPostDto.UserID,
            };
        }
        public static CommentPost ToCommentPostFromUpdateDTO(this UpdateCommentPostRequestDto commentPostUpdateDto)
        {
            return new CommentPost
            {
                PostId = commentPostUpdateDto.PostId,
                Type = commentPostUpdateDto.Type,
                UserID = commentPostUpdateDto.UserID,
            };
        }
    }
}