using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.PostDetailAlbum
{
    public class UpdatePostDetailAlbumRequestDto
    {
        public int? PostID { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "Content must be at least 5 character")]
        [MaxLength(280,ErrorMessage = "Content cannot be over 280 character")]
        public string Content { get; set; }=string.Empty;
        [Required]
        [MaxLength(30,ErrorMessage = "HashTag cannot be over 30 character")]
        public string HashTag { get; set; } = string.Empty;
        public string AlbumURL { get; set; } = string.Empty; 
    }
}