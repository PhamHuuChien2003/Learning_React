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
        public static Votesection ToVoteSectionFromCreateDTO(this CreateVoteSectionRequestDto createVoteSectionDto)
        {
            return new Votesection
            {
                PostDetailVoteID = createVoteSectionDto.PostDetailVoteID,
                VoteName = createVoteSectionDto.VoteName,
                UserID = createVoteSectionDto.UserID,
            };
        }
        public static Votesection ToVoteSectionFromUpdateDTO(this UpdateVoteSectionRequestDto createVoteSectionUpdateDto)
        {
            return new Votesection
            {
                PostDetailVoteID = createVoteSectionUpdateDto.PostDetailVoteID,
                VoteName = createVoteSectionUpdateDto.VoteName,
                UserID = createVoteSectionUpdateDto.UserID,
            };
        }
    }
}