using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentContentVideo;
using api.Models;

namespace api.Mappers
{
    public static class CommentContentVideoMapper
    {
        public static CommentContentVideoDto ToCommentContentVideoDto(this CommentContentVideo commentContentVideoModel)
        {
            return new CommentContentVideoDto
            {
                CommentContentVideoID = commentContentVideoModel.CommentContentVideoID,
                CommentPostID = commentContentVideoModel.CommentPostID,
                CommentContent = commentContentVideoModel.CommentContent,
                VideoURL = commentContentVideoModel.VideoURL,
            };
        }
        public static CommentContentVideo ToCommentContentVideoFromCreateDTO(this CreateCommentContentVideoRequestDto commentContentVideoDto)
        {
            return new CommentContentVideo
            {
                CommentPostID = commentContentVideoDto.CommentPostID,
                CommentContent = commentContentVideoDto.CommentContent,
                VideoURL = commentContentVideoDto.VideoURL,
            };
        }
    }
}