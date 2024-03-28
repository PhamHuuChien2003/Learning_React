using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class VoteResult
    {
        public int VoteResultID { get; set; }
        public int? PostDetailVoteID { get; set; }
        public PostDetailVote? PostDetailVote { get; set; }
        public int? VotesectionID { get; set; }
        public Votesection? Votesection { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}