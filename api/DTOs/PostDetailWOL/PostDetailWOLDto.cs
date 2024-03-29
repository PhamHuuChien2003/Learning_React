using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.PostDetailWOL
{
    public class PostDetailWOLDto
    {
        public int PostDetailWOLID { get; set; }
        public int? PostID { get; set; }
        public string Content { get; set; }=string.Empty;
        public string HashTag { get; set; } = string.Empty;
    }
}