using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Votesection
    {
        public int VotesectionID { get; set; }
        public int? PostDetailVoteID { get; set; }
        public PostDetailVote? PostDetailVote { get; set; }
        public string  VoteName { get; set; } = string.Empty;
        public int? UserID { get; set; }    
        public User? User { get; set; }
    }
}