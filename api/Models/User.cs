using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
    public class User 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public List<RelationshipMember> RelationshipMembers { get; set; } = new List<RelationshipMember>();
        public List<Post> Posts { get; set; } = new List<Post>();
        public string? UserAccountID {get; set;}
        public UserAccount? UserAccount {get; set;}
    }
}