using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CommentContentVideo
{
    public class CommentContentVideoDto
    {
        public int CommentContentVideoID { get; set; }
        public int? CommentPostID { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
    }
}