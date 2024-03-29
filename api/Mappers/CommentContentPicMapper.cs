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
    }
}