using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CommentPost
{
    public class UpdateCommentPostRequestDto
    {
        public int? PostId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? UserID { get; set; }
    }
}