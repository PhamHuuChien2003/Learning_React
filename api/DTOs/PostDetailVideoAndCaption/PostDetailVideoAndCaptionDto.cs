using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.PostDetailVideoAndCaption
{
    public class PostDetailVideoAndCaptionDto
    {
        public int PostDetailVideoAndCaptionID { get; set; }
        public int? PostID { get; set; }
        public string Content { get; set; }=string.Empty;
        public string HashTag { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty; 
    }
}