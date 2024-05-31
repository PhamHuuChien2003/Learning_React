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
                Votesections = postDetailVoteModel.Votesections.Select(c=>c.ToVotesectionDto()).ToList(),
            };
        }
        public static PostDetailVote ToPostDetailVoteFromCreateDTO(this CreatePostDetailVoteRequestDto postDetailVoteDto)
        {
            return new PostDetailVote
            {
                PostID = postDetailVoteDto.PostID,
                Content = postDetailVoteDto.Content,
                HashTag = postDetailVoteDto.HashTag,
                // Votesections = postDetailVoteDto.Votesections.Select(c=>c.ToVoteSectionFromCreateDTO()).ToList(),
            };
        }
        public static PostDetailVote ToPostDetailVoteFromUpdateDTO(this UpdatePostDetailVoteRequestDto postDetailVoteUpdateDto)
        {
            return new PostDetailVote
            {
                PostID = postDetailVoteUpdateDto.PostID,
                Content = postDetailVoteUpdateDto.Content,
                HashTag = postDetailVoteUpdateDto.HashTag,
                // Votesections = postDetailVoteUpdateDto.Votesections.Select(c=>c.ToVoteSectionFromUpdateDTO()).ToList(),
            };
        }
    }
}