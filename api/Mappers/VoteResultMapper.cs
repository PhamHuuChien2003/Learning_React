using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.VoteResult;
using api.Models;

namespace api.Mappers
{
    public static class VoteResultMapper
    {
        public static VoteResultDto ToVoteResultDto(this VoteResult voteResultModel)
        {
            return new VoteResultDto
            {
                VoteResultID = voteResultModel.VoteResultID,
                PostDetailVoteID = voteResultModel.PostDetailVoteID,
                VotesectionID = voteResultModel.VotesectionID,
                UserID = voteResultModel.UserID,
            };
        }
    }
}