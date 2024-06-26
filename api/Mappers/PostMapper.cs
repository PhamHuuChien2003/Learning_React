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
                UserId = postModel.UserId,
                CommentPosts = postModel.CommentPosts.Select(c => c.ToCommentPostDto()).ToList(),
                ReactPosts = postModel.ReactPosts.Select(c=>c.ToReactPostDto()).ToList(),
            };
        }
        public static Post ToPostFromCreateDTO(this CreatePostRequestDto postDto)
        {
            return new Post
            {
                Type = postDto.Type,
                Posttime = postDto.Posttime,
                UserId = postDto.UserId,
                // CommentPosts = postDto.CommentPosts.Select(c => c.ToCommentPostFromCreateDTO()).ToList(),
                // ReactPosts = postDto.ReactPosts.Select(c=>c.ToReactPostFromCreateDTO()).ToList(),
            };
        }
        public static Post ToPostFromUpdateDTO(this UpdatePostRequestDto postUpdateDto)
        {
            return new Post
            {
                Type = postUpdateDto.Type,
                Posttime = postUpdateDto.Posttime,
                UserId = postUpdateDto.UserId,
                // CommentPosts = postUpdateDto.CommentPosts.Select(c => c.ToCommentPostFromUpdateDTO()).ToList(),
                // ReactPosts = postUpdateDto.ReactPosts.Select(c=>c.ToReactPostFromUpdateDTO()).ToList(),
            };
        }
    }
}