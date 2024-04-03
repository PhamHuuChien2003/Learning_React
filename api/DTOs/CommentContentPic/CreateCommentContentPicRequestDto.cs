using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CommentContentPic
{
    public class CreateCommentContentPicRequestDto
    {
        public int? CommentPostID { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}