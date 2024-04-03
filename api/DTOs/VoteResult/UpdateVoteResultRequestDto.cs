using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.VoteResult
{
    public class UpdateVoteResultRequestDto
    {
        public int? PostDetailVoteID { get; set; }
        public int? VotesectionID { get; set; }
        public int? UserID { get; set; }
    }
}