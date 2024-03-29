using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailVote;
using api.Models;

namespace api.Mappers
{
    public static class PostDetailVoteMapper
    {
        public static PostDetailVoteDto ToPostDetailVoteDto(this PostDetailVote postDetailVoteModel)
        {
            return new PostDetailVoteDto
            {
                PostDetailVoteID = postDetailVoteModel.PostDetailVoteID,
                PostID = postDetailVoteModel.PostID,
                Content = postDetailVoteModel.Content,
                HashTag = postDetailVoteModel.HashTag,
            };
        }
    }
}