using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CommentContentVideo
    {
        public int CommentContentVideoID { get; set; }
        public int? CommentPostID { get; set; }
        public CommentPost? CommentPost { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
        
    }
}