using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Votesection
{
    public class CreateVoteSectionRequestDto
    {
        public int? PostDetailVoteID { get; set; }
        public string  VoteName { get; set; } = string.Empty;
        public int? UserID { get; set; }   
    }
}