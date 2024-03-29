using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.PostDetailSGPicWithCaption
{
    public class PostDetailSGPicWithCaptionDto
    {
        public int PostDetailSGPicWithCaptionID { get; set; }
        public int? PostID { get; set; }
        public string Content { get; set; }=string.Empty;
        public string HashTag { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}