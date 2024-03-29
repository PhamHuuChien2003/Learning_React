using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Votesection;
using api.Models;

namespace api.Mappers
{
    public static class VotesectionMapper
    {
        public static VotesectionDto ToVotesectionDto(this Votesection votesectionModel)
        {
            return new VotesectionDto
            {
                VotesectionID = votesectionModel.VotesectionID,
                PostDetailVoteID = votesectionModel.PostDetailVoteID,
                VoteName = votesectionModel.VoteName,
                UserID = votesectionModel.UserID,
            };
        }
    }
}