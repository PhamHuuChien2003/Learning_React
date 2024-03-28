using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CommentContentPic
    {
        public int CommentContentPicID { get; set; }
        public int? CommentPostID { get; set; }
        public CommentPost? CommentPost { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}