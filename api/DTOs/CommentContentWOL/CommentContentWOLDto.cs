using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CommentContentWOL
{
    public class CommentContentWOLDto
    {
        public int CommentContentWOLID { get; set; }
        public int? CommentPostID { get; set; }
        public string CommentContent { get; set; } = string.Empty;
    }
}