using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Post;
using api.DTOs.RelationshipMember;

namespace api.DTOs.User
{
    public class CreateUserRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        // public List<CreateRelationshipMemberRequestDto>? RelationshipMembers { get; set; }
        // public List<CreatePostRequestDto>? Posts { get; set; }
    }
}