using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Post;
using api.DTOs.RelationshipMember;

namespace api.DTOs.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string UserAccountID {get; set;}
        public List<RelationshipMemberDto>? RelationshipMembers { get; set; }
        public List<PostDto>? Posts { get; set; }
    }
}