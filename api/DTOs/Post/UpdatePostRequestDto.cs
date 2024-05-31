using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CommentPost;
using api.DTOs.ReactPost;

namespace api.DTOs.Post
{
    public class UpdatePostRequestDto
    {
        public string  Type { get; set; } = string.Empty;
        public DateTime Posttime { get; set; }=DateTime.Now;
        public int? UserId { get; set; }
        // public List<UpdateCommentPostRequestDto>? CommentPosts { get; set; } 
        // public List<UpdateReactPostRequestDto>? ReactPosts { get; set; } 

    }
}