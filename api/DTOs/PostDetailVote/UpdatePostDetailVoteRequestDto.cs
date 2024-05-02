using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Votesection;

namespace api.DTOs.PostDetailVote
{
    public class UpdatePostDetailVoteRequestDto
    {
        public int? PostID { get; set; }
        public string Content { get; set; }=string.Empty;
        public string HashTag { get; set; } = string.Empty;
        public List<UpdateVoteSectionRequestDto>? Votesections { get; set; }
    }
}