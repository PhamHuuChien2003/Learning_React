using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CommentContentPic
{
    public class CommentContentPicDto
    {
        public int CommentContentPicID { get; set; }
        public int? CommentPostID { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}