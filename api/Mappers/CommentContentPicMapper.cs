using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentContentPic;
using api.Models;

namespace api.Mappers
{
    public static class CommentContentPicMapper
    {
        public static CommentContentPicDto ToCommentContentPicDto(this CommentContentPic commentContentPicModel )
        {
            return new CommentContentPicDto
            {
                CommentContentPicID = commentContentPicModel.CommentContentPicID,
                CommentPostID = commentContentPicModel.CommentPostID,
                CommentContent = commentContentPicModel.CommentContent,
                ImageURL = commentContentPicModel.ImageURL,
            };
        }
        public static CommentContentPic ToCommentContentPicFromCreateDTO(this CreateCommentContentPicRequestDto commentContentPicDto)
        {
            return new CommentContentPic
            {
                CommentPostID = commentContentPicDto.CommentPostID,
                CommentContent = commentContentPicDto.CommentContent,
                ImageURL = commentContentPicDto.ImageURL,
            };
        }
        public static CommentContentPic ToCommentContentPicFromUpdateDTO(this UpdateCommentContentPicRequestDto commentContentPicUpdateDto)
        {
            return new CommentContentPic
            {
                CommentPostID = commentContentPicUpdateDto.CommentPostID,
                CommentContent = commentContentPicUpdateDto.CommentContent,
                ImageURL = commentContentPicUpdateDto.ImageURL,
            };
        }
    }
}