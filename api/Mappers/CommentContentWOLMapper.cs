using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentContentWOL;
using api.Models;

namespace api.Mappers
{
    public static class CommentContentWOLMapper
    {
        public static CommentContentWOLDto ToCommentContentWOLDto(this CommentContentWOL commentContentWOLModel)
        {
            return new CommentContentWOLDto
            {
                CommentContentWOLID = commentContentWOLModel.CommentContentWOLID,
                CommentPostID = commentContentWOLModel.CommentPostID,
                CommentContent = commentContentWOLModel.CommentContent,
            };
        }
    }
}