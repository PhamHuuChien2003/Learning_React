using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CommentContentWOL
    {
        public int CommentContentWOLID { get; set; }
        public int? CommentPostID { get; set; }
        public CommentPost? CommentPost { get; set; }
        public string CommentContent { get; set; } = string.Empty;
    }
}