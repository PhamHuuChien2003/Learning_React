using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.PostDetailAlbum
{
    public class PostDetailAlbumDto
    {
        public int PostDetailAlbumID { get; set; }
        public int? PostID { get; set; }
        public string Content { get; set; }=string.Empty;
        public string HashTag { get; set; } = string.Empty;
        public string AlbumURL { get; set; } = string.Empty; 
    }
}